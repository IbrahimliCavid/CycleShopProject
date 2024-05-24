using Buisness.Abstract;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BestRacerController : Controller
    {
       
        private readonly IBestRacerService _bestRacerService;
        private readonly IWebHostEnvironment _webEnv;
        public BestRacerController(IBestRacerService bestRacerService, IWebHostEnvironment webEnv)
        {
            _bestRacerService = bestRacerService;
            _webEnv = webEnv;
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
        public IActionResult Create(BestRacerCreateDto bestRacer, IFormFile imgUrl)
        {
            var result = _bestRacerService.Add(bestRacer, imgUrl, _webEnv.WebRootPath, out ErrorDataResult<string> error);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"{error.Data}", error.Message);
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
        public IActionResult Edit(BestRacerUpdateDto bestRacer, IFormFile imgUrl)
        {
            var result = _bestRacerService.Update(bestRacer, imgUrl, _webEnv.WebRootPath, out ErrorDataResult<string> error);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"{error.Data}", error.Message);
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
