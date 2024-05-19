using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapper
{
    public static class AboutMapper
    {
        public static AboutDto ToDto(About about)
        {
            AboutDto dto= new AboutDto()
            {
                Id = about.Id,
                Description = about.Description,
            };

            return dto;
        }

        public static List<AboutDto> ToDto(List<About> abouts)
        {
            return abouts.Select(x => ToDto(x)).ToList();
        }

        public static About ToModel(AboutCreateDto dto)
        {
            About about = new()
            {
                Description = dto.Description,
            };
            return about;
        }

        public static About ToModel(AboutDto dto)
        {
            About about = new()
            {
                Id = dto.Id,
                Description = dto.Description,

            };
            return about;
        }
        public static About ToModel(AboutUpdateDto dto)
        {
            About about = new()
            {
                Id = dto.Id,
                Description = dto.Description,
            };
            return about;
        }
    }
}
