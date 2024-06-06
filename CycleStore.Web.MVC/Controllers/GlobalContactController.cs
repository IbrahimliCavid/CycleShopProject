using Buisness.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.MemberShip;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Controllers
{
    public class GlobalContactController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContactService _contactService;

        public GlobalContactController(UserManager<ApplicationUser> userManager, IContactService contactService)
        {
            _userManager = userManager;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["User"] = await _userManager.GetUserAsync(User);
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Name", result.Message);
                ViewBag.Message = "jksdand";
                return View(dto);
            }
            return RedirectToAction("Create");

        }
    }
}
