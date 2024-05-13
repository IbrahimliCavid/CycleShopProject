using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BigSaleController : Controller
    {
        BigSaleManager _bigSaleManager = new BigSaleManager();
        public IActionResult Index()
        {
            var data = _bigSaleManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BigSale bigSale)
        {
            var result = _bigSaleManager.Add(bigSale);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(bigSale);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bigSaleManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BigSale bigSale)
        {
            var result = _bigSaleManager.Update(bigSale);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(bigSale);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _bigSaleManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
