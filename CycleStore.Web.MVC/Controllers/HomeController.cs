using Buisness.Abstract;
using CycleStore.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CycleStore.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IActivityService _activityService;
        private readonly IBestRacerService _bestRacerService;
        private readonly ICycleService _cycleService;
        private readonly IServiceService _serviceService;
        private readonly ITestimonialService _testimonialService;

        public HomeController(IAboutService aboutService, IActivityService activityService, IBestRacerService bestRacerService,ICycleService cycleService,  IServiceService serviceService, ITestimonialService testimonialService)
        {
            _aboutService = aboutService;
            _activityService = activityService;
            _bestRacerService = bestRacerService;
            _serviceService = serviceService;
            _testimonialService = testimonialService;
            _cycleService = cycleService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var activityData = _activityService.GetAll().Data;
            var bestRacerData = _bestRacerService.GetAll().Data;
            var cycleData = _cycleService.GetProductWithCycleCategoryId().Data;
            var serviceData = _serviceService.GetAll().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            HomeViewModel viewModel = new()
            {
                Abouts  = aboutData,
                Activities = activityData,
                BestRacers = bestRacerData,
                Cycles = cycleData,
                Services = serviceData,
                Testimonials = testimonialData, 
            };
            return View(viewModel);
        }

    }
}
