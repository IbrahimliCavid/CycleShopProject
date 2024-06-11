using Buisness.Abstract;
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

        public GlobalCartController(UserManager<ApplicationUser> userManager, ICartService cartService, ICycleService cycleService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cycleService = cycleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeToCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.GetAll().Data.Find(x => x.UserId == user.Id);

           
          
                Cart newCart = new Cart()
                {
                    UserId = user.Id,
                };
                newCart.CycleId = id;
                var result = _cartService.Add(newCart);
            return View();
            }
         
       
    }
}
