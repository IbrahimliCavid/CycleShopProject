using Buisness.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.MemberShip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Controllers
{
    [Authorize]
    public class GlobalShippingAdressController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShippingAdressService _shippingService;

        public GlobalShippingAdressController(UserManager<ApplicationUser> userManager, IShippingAdressService shippingService)
        {
            _userManager = userManager;
            _shippingService = shippingService;
        }

        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            ViewData["User"] = await _userManager.GetUserAsync(User);
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(ShippingAdressCreateDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            dto.UserId = user.Id;
            var result = _shippingService.Add(dto);
            if (!result.IsSuccess)
            {
                return Json(new { isSuccess = false });
            }
            return Json(new { isSuccess = true });
        }
    }
}
