using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.MemberShip;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CycleStore.Web.MVC.Controllers
{
    public class GlobalCartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;
        private readonly ICycleService _cycleService;
        private readonly ICartItemService _cartItemService;

        public GlobalCartController(UserManager<ApplicationUser> userManager, ICartService cartService, ICycleService cycleService, ICartItemService cartItemService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cycleService = cycleService;
            _cartItemService = cartItemService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["User"] = await _userManager.GetUserAsync(User);
            var data = _cartItemService.GetAll().Data;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeToCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.GetAll().Data.Find(x => x.UserId == user?.Id);
            if (cart == null)
            {
                Cart newCart = new()
                {
                    UserId = user.Id
                };
                
                _cartService.Add(newCart);
                cart = newCart; 
            }

            CartItem newCartItem = new CartItem()
            {
                CartId = cart.Id,
                CycleId = id,
                Quantity = 1
            };
            var existingCartItem = _cartItemService.GetAll().Data.Find(x => x.CartId == newCartItem.CartId && x.CycleId == newCartItem.CycleId);

            if (existingCartItem == null)
            {
                var result = _cartItemService.Add(newCartItem);
                if (!result.IsSuccess) return Json(new { isSuccess = false });
                return Json(new { isSuccess = true });
            }
            else
            {
                existingCartItem.Quantity++;
                var result = _cartItemService.Update(existingCartItem);
                if (!result.IsSuccess) return Json(new { isSuccess = false });
                return Json(new { isSuccess = true });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PlusBike(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var existingCartItem = _cartItemService.GetAll().Data.Find(x =>x.UserId == user.Id && x.CycleId == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                var result = _cartItemService.Update(existingCartItem);
                if (!result.IsSuccess) return Json(new { isSuccess = false });
                return Json(new { isSuccess = true });
            }

            return Json(new { isSuccess = false });
        }

        [HttpPost]
        public async Task<IActionResult> MinusBike(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var existingCartItem = _cartItemService.GetAll().Data.Find(x => x.UserId == user.Id && x.CycleId == id);
            if (existingCartItem != null && existingCartItem.Quantity > 1)
            {
                existingCartItem.Quantity--;
                var result = _cartItemService.Update(existingCartItem);
                if (!result.IsSuccess) return Json(new { isSuccess = false });
                return Json(new { isSuccess = true });
            }

            return Json(new { isSuccess = false });
        }

        [HttpPost]
        public IActionResult RemoveBike(int id)
        {
            var result = _cartItemService.Delete(id);
            if (!result.IsSuccess) return Json(new { isSuccess = false });
            return Json(new { isSuccess = true });
        }
    }
}
