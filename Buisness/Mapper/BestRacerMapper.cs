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
            };
            return dto;
        }

        public static List<BestRacerDto> ToDto(List<BestRacer> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
