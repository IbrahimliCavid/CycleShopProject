using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace CycleStore.Web.MVC.ViewModels
{
    public class HomeViewModel
    {
       public List<AboutDto> Abouts { get; set; }
        public List<ActivityDto> Activities { get; set; }

        public List<BestRacerDto> BestRacers { get; set; }

        public List<CycleDto> Cycles { get; set; }

        public List<ServiceDto> Services { get; set; }

        public List<TestimonialDto> Testimonials { get; set; }
    }
}
