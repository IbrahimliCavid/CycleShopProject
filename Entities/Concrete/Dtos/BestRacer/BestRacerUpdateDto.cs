using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BestRacerUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string EmailLink { get; set; }
        public static BestRacer ToModel(BestRacerUpdateDto dto)
        {
            BestRacer bestRacer = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Info = dto.Info,
                ImgUrl = dto.ImgUrl,
                FacebookLink = dto.FacebookLink,
                InstagramLink = dto.InstagramLink,
                EmailLink = dto.EmailLink,
                TwitterLink = dto.TwitterLink
            };
            return bestRacer;
        }
    }
}
