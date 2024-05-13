using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
