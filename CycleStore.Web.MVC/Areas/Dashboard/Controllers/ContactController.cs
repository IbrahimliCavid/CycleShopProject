using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager();

        public IActionResult Index()
        {
            var data = _contactManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            var result = _contactManager.Add(contact);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _contactManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var result = _contactManager.Update(contact);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _contactManager.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
