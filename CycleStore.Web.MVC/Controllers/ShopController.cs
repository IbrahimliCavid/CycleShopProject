using Buisness.Abstract;
using CycleStore.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CycleStore.Web.MVC.Controllers
{
    public class ShopController : Controller
    {

        private readonly IBestRacerService _bestRacerService;
        private readonly ICycleService _cycleService;
        private readonly IBigSaleService _bigSaleService;

        public ShopController(IBestRacerService bestRacerService, ICycleService cycleService, IBigSaleService bigSaleService)
        {
            _bestRacerService = bestRacerService;
            _cycleService = cycleService;
            _bigSaleService = bigSaleService;
        }

        public IActionResult Index()
        {
            var bestRacerData = _bestRacerService.GetAll().Data;
            var cycleData = _cycleService.GetProductWithCycleCategoryId().Data;
            var bigSaleData = _bigSaleService.GetAll().Data;

            ShopViewModel viewModel = new()
            {
                BestRacers = bestRacerData,
                Cycles = cycleData,
                BigSales = bigSaleData
            };
            return View(viewModel);
        }
    }
}
