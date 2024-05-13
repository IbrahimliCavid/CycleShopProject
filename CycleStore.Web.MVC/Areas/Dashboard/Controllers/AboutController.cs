using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager();
        public IActionResult Index()
        {
            var data = _aboutManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            var result = _aboutManager.Add(about);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(about);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            var result = _aboutManager.Update(about);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(about);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _aboutManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
