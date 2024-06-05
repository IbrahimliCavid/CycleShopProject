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
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _contactService.GetById(id).Data;
            return View(ContactMapper.ToUpdateDto(data));
        }

        [HttpPost]
        public IActionResult Edit(ContactUpdateDto dto)
        {
            var result = _contactService.Update(dto);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _contactService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
