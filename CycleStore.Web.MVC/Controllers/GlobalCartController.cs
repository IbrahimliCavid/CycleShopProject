using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.MemberShip;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

                CartItem newCartItem = new CartItem()
                {
                    CartId = newCart.Id,
                    CycleId = id,
                };
                _cartService.Add(newCart);
                var data = _cartItemService.GetAll().Data.Find(x=>x.CartId == newCartItem.CartId && x.CycleId == newCartItem.CycleId);

                if (data == null )
                {
                    _cartItemService.Add(newCartItem);
                }
                else
                {
                    data.Quantity++;

                    _cartItemService.Update(data);
                }
              

            }
            else
            {

                CartItem newCartItem = new CartItem()
                {
                    CartId = cart.Id,
                    CycleId = id,
                };
                var data = _cartItemService.GetAll().Data.Find(x => x.CartId == newCartItem.CartId && x.CycleId == newCartItem.CycleId);

                if (data == null)
                {
                    _cartItemService.Add(newCartItem);
                }
                else
                {
                    data.Quantity++;
                    _cartItemService.Update(data);
                }

            }
            return View("Index");
            

        }
    }
}
