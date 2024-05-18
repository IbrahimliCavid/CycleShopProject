using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHomePage { get; set; }
        public string ImgUrl { get; set; }


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
