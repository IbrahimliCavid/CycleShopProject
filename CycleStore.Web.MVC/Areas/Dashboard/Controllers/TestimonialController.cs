using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestimonialController : Controller
    {
        TestimonialManager _testimonialManager = new();

        public IActionResult Index()
        {
            var data = _testimonialManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            var result = _testimonialManager.Add(testimonial);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(testimonial);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Testimonial testimonial)
        {
            var result = _testimonialManager.Update(testimonial);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _testimonialManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
