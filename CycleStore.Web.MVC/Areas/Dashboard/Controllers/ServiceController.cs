using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var data = _serviceService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto)
        {
            var result = _serviceService.Add(dto);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _serviceService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServiceUpdateDto dto)
        {
            var result = _serviceService.Update(dto);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _serviceService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
