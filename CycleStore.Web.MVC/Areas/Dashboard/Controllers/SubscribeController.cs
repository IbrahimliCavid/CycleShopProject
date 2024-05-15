using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SubscribeController : Controller
    {
        SubscribeManager _subscribeManager = new();
     
        public IActionResult Index()
        {
            var data = _subscribeManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subscribe subscribe)
        {
            var result = _subscribeManager.Add(subscribe);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(subscribe);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _subscribeManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Subscribe subscribe)
        {
            var result = _subscribeManager.Update(subscribe);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(subscribe);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _subscribeManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }

    }
}
