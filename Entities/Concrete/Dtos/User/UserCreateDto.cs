using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class UserCreateDto
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static User ToModel(UserCreateDto dto)
        {
            User user = new()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
            };
            return user;
        }
    }
}
