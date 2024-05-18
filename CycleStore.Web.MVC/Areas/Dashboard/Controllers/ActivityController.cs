using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ActivityController : Controller
    {
       private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityManager)
        {
            _activityService = activityManager;
        }

        public IActionResult Index()
        {
           var data = _activityService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ActivityCreateDto dto)
        {
            var result = _activityService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _activityService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ActivityUpdateDto dto)
        {
            var result = _activityService.Update(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _activityService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
