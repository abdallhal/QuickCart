using Microsoft.AspNetCore.Mvc;
using QuickCart.Domain.DTO;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service; 
                
        }
        public IActionResult Index()
        {
            return View();

 
        }

       

        public IActionResult Create()
        {

            return View("ProductForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormDTO productDTO)
        {

            if (ModelState.IsValid)
            {
                var result = _service.Create(productDTO);
                if (result.Success)
                {
                    TempData["createMesage"] = "Item created successfully!";
                    return RedirectToAction(nameof(Index));

                }
                TempData["deleteMesage"] = result.Message;
                return View(productDTO);
            }

            return View(productDTO);
        }


        public IActionResult Edit(int id)
        {

            var result = _service.FirstOrDefault(id);
            if (result.Success)
            {
                return View("ProductForm",result.Data);
            }

            TempData["deleteMesage"] = result.Message;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormDTO productDTO)
        {
            if (ModelState.IsValid)
            {

               var result = _service.Update(productDTO);

                if (result.Success)
                {
                    TempData["editMesage"] = "Item edited successfully!";
                    return RedirectToAction(nameof(Index));
                }


            }
            return View(productDTO);

        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();

            }

            var result = _service.FirstOrDefault(id);

            return View(result.Data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {

            var category = _service.FirstOrDefault(id);

            if (category == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            TempData["deleteMesage"] = "Item deleted.";
            return RedirectToAction(nameof(Index));



        }
    }
}
