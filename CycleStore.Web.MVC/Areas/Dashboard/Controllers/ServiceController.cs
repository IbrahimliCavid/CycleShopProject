using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager = new ServiceManager();
        public IActionResult Index()
        {
            var data = _serviceManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            var result = _serviceManager.Add(service);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(service);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _serviceManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            var result = _serviceManager.Update(service);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(service);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _serviceManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
