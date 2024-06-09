using Buisness.Abstract;
using Buisness.Mapper;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ShippingAdressController : Controller
    {
        private readonly IShippingAdressService _shippingAdressService;

        public ShippingAdressController(IShippingAdressService shippingAdressService)
        {
            _shippingAdressService = shippingAdressService;
        }

        public IActionResult Index()
        {
            var data = _shippingAdressService.GetShippingAdressWithUser().Data;
            return View(data);
        }

      

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _shippingAdressService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
