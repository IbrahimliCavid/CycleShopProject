using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class BestRacerMapper
    {
        public static BestRacerDto ToDto(BestRacer model)
        {
            BestRacerDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Info = model.Info,
                ImgUrl = model.ImgUrl,
                FacebookLink = model.FacebookLink,
                InstagramLink = model.InstagramLink,
                EmailLink = model.EmailLink,
                TwitterLink = model.TwitterLink
            };
            return dto;
        }

        public static List<BestRacerDto> ToDto(List<BestRacer> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
        public static BestRacer ToModel(BestRacerCreateDto dto)
        {
            BestRacer bestRacer = new()
            {
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

        public static BestRacer ToModel(BestRacerDto dto)
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
