
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;
using QuickCart.Repo;
using System.Linq.Dynamic.Core;

namespace QuickCart.Services
{
    public class ProductService : IProductService
    {


        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IFileService _fileService;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }





        public ServiceResponse<IEnumerable<ProductDTO>> GetAll()
        {
            var list = _unitOfWork.Product.GetAll();
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(list);
            return ServiceResponse<IEnumerable<ProductDTO>>.DeliverData(productDTOs);
        }

        public ServiceResponse<IEnumerable<ProductDTO>> GetAll(GetAllBaseRequestDTO requestDTO)
        {
           
            var products = _unitOfWork.Product.GetAll();

            if (products.Any())
            {
      
                // Apply search filters
                var productsAsQueryable = products
                                       .Where(product => string.IsNullOrWhiteSpace(requestDTO.Search.SearchValue) ||
                                       requestDTO.Search.SearchValue.ToLower().Contains(product.Name.ToLower())).AsQueryable();
               new GridDataTable().GetSortedData(ref productsAsQueryable, requestDTO);

                if (productsAsQueryable.Any())
                {
                 
                    var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(productsAsQueryable);
                    var result = ServiceResponse<IEnumerable<ProductDTO>>.DeliverData(productDTOs);
                    result.TotalRecords = products.Count();
                    return result;
                }
            }
  
            return ServiceResponse<IEnumerable<ProductDTO>>.DeliverData( new List<ProductDTO>());

        }

        public ServiceResponse<ProductFormDTO> FirstOrDefault(int id)
        {

            var product = _unitOfWork.Product.FirstOrDefault(o => o.Id == id, c => c.ProductImages);

            if (product == null)
            {
                return ServiceResponse<ProductFormDTO>.ReportError("Invalid product");
            }
            var data = _mapper.Map<ProductFormDTO>(product);
            return ServiceResponse<ProductFormDTO>.DeliverData(data);
        }

        public List<string> HandleFiles(Product product, ProductFormDTO productFormDTO)
        {

            var isEdit = product.Id != 0;

            var filesName = UploadedFiles(productFormDTO.Images!);

            var newImages = filesName.Select(fileName => new ProductImage { Product = product, ImageUrl = fileName  ,IsMain }).ToList();

            if (newImages.Any())
            {

                foreach (var image in newImages)
                {
                    product.ProductImages.Add(image);
                }
            }

            // Remove old images based on filenames

            if (isEdit && !string.IsNullOrEmpty(productFormDTO.FilesNameToRemove))
            {
                var filesToRemove = productFormDTO.FilesNameToRemove.Split(",").ToList();
                product.ProductImages = product.ProductImages
               .Where(image => !filesToRemove.Contains(image.ImageUrl))
               .ToList();

            }


            return filesName;
        }
        public ServiceResponse<ProductFormDTO> Create(ProductFormDTO productDTO)
        {
            if (productDTO == null)
            {
                return ServiceResponse<ProductFormDTO>.ReportError("Product data is null.");
            }

            var product = _mapper.Map<Product>(productDTO);

            var newFilesName = HandleFiles(product, productDTO);

            try
            {

                _unitOfWork.Product.Add(product);

                var result = _unitOfWork.Complete();

                if (result == 0)
                {
                    _fileService.RemoveFiles(newFilesName);
                    return ServiceResponse<ProductFormDTO>.ReportError("Failed to save product.");
                }

                return ServiceResponse<ProductFormDTO>.DeliverData(productDTO);
            }
            catch (DbUpdateException ex)
            {
                if (newFilesName != null && newFilesName.Any())
                {
                    _fileService.RemoveFiles(newFilesName);
                }
                return ServiceResponse<ProductFormDTO>.ReportError($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (newFilesName != null && newFilesName.Any())
                {
                    _fileService.RemoveFiles(newFilesName);
                }
                return ServiceResponse<ProductFormDTO>.ReportError($"An error occurred: {ex.Message}");
            }
        }


        public List<string> UploadedFiles(List<IFormFile> images)
        {
            var filesName = _fileService.CreateRange(images);
            return filesName;
        }
        public ServiceResponse<ProductFormDTO> Update(ProductFormDTO productDTO)
        {

            var product = _unitOfWork.Product.FirstOrDefault(c => c.Id == productDTO.Id, p => p.ProductImages);

            if (product == null)
            {
                return ServiceResponse<ProductFormDTO>.ReportError("product is null");
            }

            _mapper.Map(productDTO, product);

            var newFilesName = HandleFiles(product, productDTO);
            try
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Complete();

                // Remove old files from server after ensuring the update was successful
                if (!string.IsNullOrEmpty(productDTO.FilesNameToRemove))
                {
                    var oldFilesToRemove = productDTO.FilesNameToRemove.Split(',').ToList();
                    _fileService.RemoveFiles(oldFilesToRemove);
                }


                return ServiceResponse<ProductFormDTO>.DeliverData(productDTO);
            }
            catch (DbUpdateException ex)
            {
                if (newFilesName != null && newFilesName.Any())
                {
                    _fileService.RemoveFiles(newFilesName);
                }
                return ServiceResponse<ProductFormDTO>.ReportError($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (newFilesName != null && newFilesName.Any())
                {
                    _fileService.RemoveFiles(newFilesName);
                }
                return ServiceResponse<ProductFormDTO>.ReportError($"An error occurred: {ex.Message}");
            }


        }


        public ServiceResponse<bool> Delete(int id)
        {

            var product = _unitOfWork.Product.FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return ServiceResponse<bool>.ReportError("product is null");
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Complete();
            return ServiceResponse<bool>.DeliverData(true);

        }


        public void HandleUploadFiles(Product product)
        {

        }
    }
}

