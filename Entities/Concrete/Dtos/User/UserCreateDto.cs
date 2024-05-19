using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class UserCreateDto
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
