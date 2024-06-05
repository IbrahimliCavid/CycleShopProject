using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Mapper;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class BigSaleController : Controller
    {
        private readonly IBigSaleService _bigSaleService;
        private readonly IWebHostEnvironment _webEnv;
        public BigSaleController(IBigSaleService bigSaleService, IWebHostEnvironment webEnv)
        {
            _bigSaleService = bigSaleService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _bigSaleService.GetAll().Data;
            ViewBag.ShowButton = data.Count() == 0;
            
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BigSaleCreateDto bigSale, IFormFile imgUrl)
        {
            var result = _bigSaleService.Add(bigSale, imgUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("ImgUrl", result.Message);
                return View(bigSale);
            }
                
                return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bigSaleService.GetById(id).Data;
            return View(BigSaleMapper.ToUpdateDto(data));
        }

        [HttpPost]
        public IActionResult Edit(BigSaleUpdateDto bigSale, IFormFile imgUrl)
        {
            var result = _bigSaleService.Update(bigSale, imgUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("ImgUrl", result.Message);
                return View(bigSale);
            }
                return RedirectToAction("Index");
         
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _bigSaleService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
