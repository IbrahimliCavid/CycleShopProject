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

        public static Subscribe ToModel(SubscribeCreateDto dto)
        {
            Subscribe subscribe = new()
            {
                Email = dto.Email,
            };
            return subscribe;
        }

        public static Subscribe ToModel(SubscribeDto dto)
        {
            Subscribe subscribe = new()
            {
                Id = dto.Id,
                Email = dto.Email,
            };
            return subscribe;
        }

        public static Subscribe ToModel(SubscribeUpdateDto dto)
        {
            Subscribe subscribe = new()
            {
                Id = dto.Id,
                Email = dto.Email,
            };
            return subscribe;
        }
    }
}
