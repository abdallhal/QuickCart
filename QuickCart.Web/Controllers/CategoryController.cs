using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickCart.DataAccess.Models;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;
using QuickCart.Services;

namespace QuickCart.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly QuickCartDbContext _context;

        private readonly IMapper _mapper;

        private readonly ICategoryService _service;
        public CategoryController(QuickCartDbContext context,IMapper mapper, ICategoryService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }
        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories.Data);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryDTO categoryDto)
        {

            if (ModelState.IsValid)
            {
                _service.Create(categoryDto);
                TempData["createMesage"] = "Item created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);

        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            var category = _context.Categories.Find(id);

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();

                TempData["editMesage"] = "Item edited successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            var category = _context.Categories.Find(id);

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {

            var category = _context.Categories.Find(id);

            if (category==null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["deleteMesage"] = "Item deleted."; 
            return RedirectToAction(nameof(Index));



        }

    }
}
