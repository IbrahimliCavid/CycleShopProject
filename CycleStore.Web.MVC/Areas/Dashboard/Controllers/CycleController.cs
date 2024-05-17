using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CycleController : Controller
    {
        private readonly ICycleService _cycleService;
        private readonly ICategoryService _categoryService;

        public CycleController(ICycleService cycleService, ICategoryService categoryService)
        {
            _cycleService = cycleService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var data = _cycleService.GetProductWithCycleCategoryId().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = _categoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CycleCreateDto dto)
        {
            var result = _cycleService.Add(dto);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(dto);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categories"] = _categoryService.GetAll().Data;
            var data = _cycleService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CycleUpdateDto dto)
        {
            var result = _cycleService.Update(dto);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(dto);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _cycleService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
