using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ActivityController : Controller
    {
        ActivityManager _activityManager = new();
        public IActionResult Index()
        {
           var data = _activityManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            var result = _activityManager.Add(activity);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(activity);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _activityManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Activity activity)
        {
            var result = _activityManager.Update(activity);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(activity);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _activityManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
