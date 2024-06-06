using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult ErrorNotFound()
        {

            return View();
        }
    }
}
