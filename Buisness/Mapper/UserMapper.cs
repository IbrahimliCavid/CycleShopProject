using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class UserMapper
    {
        public static UserDto ToDto(User model)
        {
            UserDto dto = new()
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
            };
            return dto;
        }

        public static List<UserDto> ToDto(List<User> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
