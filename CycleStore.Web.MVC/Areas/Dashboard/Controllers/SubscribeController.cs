using Buisness.Abstract;
using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

     
        public IActionResult Index()
        {
            var data = _subscribeService.GetAll().Data;
            return View(data);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _subscribeService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }

    }
}
