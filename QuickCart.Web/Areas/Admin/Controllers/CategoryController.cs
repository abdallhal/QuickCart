using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
   
      

        private readonly ICategoryService _service;
        public CategoryController( ICategoryService service)
        {

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
                var result = _service.Create(categoryDto);

                if (result.Success)
                {
                    TempData["createMesage"] = "Item created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["deleteMesage"] = result.Message;
                return View(categoryDto);
            }

            return View(categoryDto);
        }


        public IActionResult Edit(int id)
        {

            var result = _service.FirstOrDefault(id);
            if (result.Success)
            {
                return View(result.Data);
            }

            TempData["deleteMesage"] = result.Message;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {


                var result = _service.Update(categoryDTO);

                if (result.Success)
                {
                    TempData["editMesage"] = "Item edited successfully!";
                    return RedirectToAction(nameof(Index));

                }


            }
            return View(categoryDTO);

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


        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {


            var response =await _service.GetAllSelectListItemAsync();
  
            return Json(response);
           
        }

    }
}
