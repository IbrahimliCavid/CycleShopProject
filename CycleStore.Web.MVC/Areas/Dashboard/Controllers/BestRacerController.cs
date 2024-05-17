using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BestRacerController : Controller
    {
       
        private readonly IBestRacerService _bestRacerService;

        public BestRacerController(IBestRacerService bestRacerService)
        {
            _bestRacerService = bestRacerService;
        }

        public IActionResult Index()
        {
            var data = _bestRacerService.GetAll().Data;
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
            var result = _bestRacerService.Add(bestRacer);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(bestRacer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bestRacerService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BestRacer bestRacer)
        {
            var result = _bestRacerService.Update(bestRacer);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(bestRacer);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _bestRacerService.Delete(id);
            if (result.IsSuccess) 
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
