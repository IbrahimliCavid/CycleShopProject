using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class SubscribeMapper
    {
        public static SubscribeDto ToDto(Subscribe model)
        {
            SubscribeDto dto = new()
            {
                Id = model.Id,
                Email = model.Email,
            };
            return dto;
        }

        public static List<SubscribeDto> ToDto(List<Subscribe> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
