using Buisness.Abstract;
using CycleStore.Web.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.ViewComponents
{
    public class TestViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public TestViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var count = _categoryService.GetAll().Data.Count();

            return View(new TestViewModel()
            {
                Count = count
            });
        }
    }
}
