using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CycleCategoryController : Controller
    {
        CycleCategoryManager _cycleCategoryManager = new();
        public IActionResult Index()
        {
            var data = _cycleCategoryManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CycleCategory cycleCategory)
        {
           var result =  _cycleCategoryManager.Add(cycleCategory);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(cycleCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _cycleCategoryManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CycleCategory bigSale)
        {
            var result = _cycleCategoryManager.Update(bigSale);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(bigSale);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _cycleCategoryManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }

    }
}
