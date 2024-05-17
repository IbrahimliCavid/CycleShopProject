using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var data = _categoryService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cycleCategory)
        {
           var result = _categoryService.Add(cycleCategory);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(cycleCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _categoryService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category bigSale)
        {
            var result = _categoryService.Update(bigSale);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(bigSale);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }

    }
}
