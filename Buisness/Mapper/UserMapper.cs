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
