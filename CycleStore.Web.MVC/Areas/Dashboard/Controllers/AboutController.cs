using Buisness.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    public class AboutController : Controller
    {
        private readonly IAboutService _abouService;
        public AboutController(IAboutService aboutService)
        {
            _abouService = aboutService;
        }

        public IActionResult Index()
        {
            var data = _abouService.GetAll().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutCreateDto dto)
        {
            var result = _abouService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Description", result.Message);
                return View();
            }
                return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _abouService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AboutUpdateDto dto)
        {
            var result = _abouService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Description", result.Message);
                return View(dto);
            }
              
           
            return RedirectToAction("Index");
        }

       
    }
}
