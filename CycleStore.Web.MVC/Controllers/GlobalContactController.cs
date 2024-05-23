using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Controllers
{
    public class GlobalContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
