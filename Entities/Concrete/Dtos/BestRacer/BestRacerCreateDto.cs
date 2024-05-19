using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BestRacerCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string EmailLink { get; set; }
      
    }
}
