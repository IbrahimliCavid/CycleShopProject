using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static User ToModel(UserUpdateDto dto)
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
