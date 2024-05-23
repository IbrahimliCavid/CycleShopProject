using Entities.Concrete.Dtos;

namespace CycleStore.Web.MVC.ViewModels
{
    public class AboutViewModel
    {
        public List<AboutDto> Abouts { get; set; }
        public List<ActivityDto> Activities { get; set; }

        public List<BestRacerDto> BestRacers { get; set; }

        public List<ServiceDto> Services { get; set; }

    }
}
