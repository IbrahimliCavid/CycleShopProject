using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHomePage { get; set; }
        public string ImgUrl { get; set; }
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
    }
}
