using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BestRacerController : Controller
    {
       
        BestRacerManager _bestRacerManager = new BestRacerManager();
        public IActionResult Index()
        {
            var data = _bestRacerManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BestRacer bestRacer)
        {
            var result = _bestRacerManager.Add(bestRacer);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(bestRacer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bestRacerManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BestRacer bestRacer)
        {
            var result = _bestRacerManager.Update(bestRacer);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(bestRacer);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _bestRacerManager.Delete(id);
            if (result.IsSuccess) 
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
