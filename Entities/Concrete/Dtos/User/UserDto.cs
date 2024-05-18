using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static User ToModel(UserDto dto)
        {
            User user = new()
            {
                Id = dto.Id,
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
            };
            return user;
        }
    }
}
