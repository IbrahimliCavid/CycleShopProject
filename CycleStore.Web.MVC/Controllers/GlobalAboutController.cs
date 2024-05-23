using Buisness.Abstract;
using CycleStore.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Controllers
{
    public class GlobalAboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IActivityService _activityService;
        private readonly IBestRacerService _bestRacerService;
        private readonly ICycleService _cycleService;
        private readonly IServiceService _serviceService;
        private readonly ITestimonialService _testimonialService;

        public GlobalAboutController(IAboutService aboutService, IActivityService activityService, IBestRacerService bestRacerService, ICycleService cycleService, IServiceService serviceService, ITestimonialService testimonialService)
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
            var serviceData = _serviceService.GetAll().Data;
            AboutViewModel viewModel = new()
            {
                Abouts = aboutData,
                Activities = activityData,
                BestRacers = bestRacerData,
                Services = serviceData,
            };
            return View(viewModel);
        }
    }
}
