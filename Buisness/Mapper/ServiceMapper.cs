using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class ServiceMapper
    {
        public static ServiceDto ToDto(Service model)
        {
            ServiceDto dto = new()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsHomePage = model.IsHomePage,
                ImgUrl = model.ImgUrl,
            };
            return dto;
        }

        public static List<ServiceDto> ToDto(List<Service> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
