using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class AboutCreateDto
    {
        public string Description {  get; set; }
        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new()
            {
                Description = dto.Description,
            };
            return about;
        }
    }
}
