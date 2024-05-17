using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var data = _userService.GetAll().Data;
            return View(data);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
