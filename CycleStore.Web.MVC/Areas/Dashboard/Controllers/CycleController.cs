using Buisness.Abstract;
using Buisness.Mapper;
using Buisness.Validations;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class CycleController : Controller
    {
        private readonly ICycleService _cycleService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webEnv;
        public CycleController(ICycleService cycleService, ICategoryService categoryService, IWebHostEnvironment webEnv)
        {
            _cycleService = cycleService;
            _categoryService = categoryService;
            _webEnv = webEnv;
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
        public IActionResult Create(CycleCreateDto dto, IFormFile imgUrl)
        {
           
            var result = _cycleService.Add(dto, imgUrl, _webEnv.WebRootPath, out ErrorDataResult<string> error);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError($"{error.Data}",error.Message);
                ViewData["Categories"] = _categoryService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categories"] = _categoryService.GetAll().Data;
            var data = _cycleService.GetById(id).Data;
            return View(CycleMapper.ToUpdateDto(data));
        }

        [HttpPost]
        public IActionResult Edit(CycleUpdateDto dto, IFormFile imgUrl)
        {
            var result = _cycleService.Update(dto, imgUrl, _webEnv.WebRootPath, out ErrorDataResult<string> error);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"{error.Data}", error.Message);
                ViewData["Categories"] = _categoryService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

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
