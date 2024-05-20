using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Mapper;
using Entities.Concrete.Dtos;
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
        public IActionResult Create(BestRacerCreateDto bestRacer)
        {
            var result = _bestRacerService.Add(bestRacer);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(bestRacer);
            }
                return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bestRacerService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BestRacerUpdateDto bestRacer)
        {
            var result = _bestRacerService.Update(bestRacer);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(bestRacer);
            }
                return RedirectToAction("Index");
            
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
