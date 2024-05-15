using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        ProductManager _productManager = new();
        CycleCategoryManager _cycleCategoryManager = new();
        public IActionResult Index()
        {
            var data = _productManager.GetProductWithCycleCategoryId().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CycleCategories"] = _cycleCategoryManager.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productManager.Add(product);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(product);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["CycleCategories"] = _cycleCategoryManager.GetAll().Data;
            var data = _productManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var result = _productManager.Update(product);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(product);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _productManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
