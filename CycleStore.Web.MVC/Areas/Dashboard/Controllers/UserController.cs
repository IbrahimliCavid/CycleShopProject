using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class UserController : Controller
    {
        UserManager _userManager = new();
        public IActionResult Index()
        {
            var data = _userManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var result = _userManager.Add(user);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _userManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var result = _userManager.Update(user);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _userManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
