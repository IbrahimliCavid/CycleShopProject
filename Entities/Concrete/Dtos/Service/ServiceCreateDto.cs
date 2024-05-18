using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHomePage { get; set; }
        public string ImgUrl { get; set; }
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
    }
}
