using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class SubscribeDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public static Subscribe ToModel(SubscribeDto dto)
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
