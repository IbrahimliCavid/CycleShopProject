using Buisness.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ActivityController : Controller
    {
        ActivityManager _activityManager = new();
        public IActionResult Index()
        {
           var data = _activityManager.GetAll().Data;
            return View(data);
        }

    }
}
