using Microsoft.AspNetCore.Mvc;
using QuickCart.Domain.DTO;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _service;
        public SubCategoryController(ISubCategoryService service)
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

            var createSubCategoryVM = new CreateSubCategoryVM();

            createSubCategoryVM.Categories = _service.GetAllCategory().Data.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = c.Name,
                Value= c.Id.ToString(), 
            });
            return View(createSubCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSubCategoryDTO subCategoryDTO)
        {

            if (ModelState.IsValid)
            {
                var result = _service.Create(subCategoryDTO);
                if (result.Success)
                {
                    TempData["createMesage"] = "Item created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["deleteMesage"] = result.Message;
                return View(subCategoryDTO);
            }

            return View(subCategoryDTO);
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
        public IActionResult Edit(SubCategoryDTO categoryDTO)
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
    }
}
