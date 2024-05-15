using Buisness.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        ProductManager _productManager = new();
        public IActionResult Index()
        {
           var data = _productManager.GetAll().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
          var result = _productManager.Add(product);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(product  );
           
        }
    }
}
