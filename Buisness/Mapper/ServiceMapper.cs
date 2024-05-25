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


        public static ServiceUpdateDto ToUpdateDto(Service model)
        {
            ServiceUpdateDto dto = new()
            {
                Id = model.Id,
                Title = model.Title,
                IsHomePage = model.IsHomePage,
                Description = model.Description,
                ImgUrl = model.ImgUrl
                
            };
            return dto;
        }

        public static Service ToModel(ServiceCreateDto dto)
        {
            Service service = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                IsHomePage = dto.IsHomePage,
                ImgUrl = dto.ImgUrl,

            };
            return service;
        }

        public static Service ToModel(ServiceDto dto)
        {
            Service service = new()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IsHomePage = dto.IsHomePage,
                ImgUrl = dto.ImgUrl,

            };
            return service;
        }


        public static Service ToModel(ServiceUpdateDto dto)
        {
            Service service = new()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IsHomePage = dto.IsHomePage,
                ImgUrl = dto.ImgUrl,

            };
            return service;
        }
    }
}
