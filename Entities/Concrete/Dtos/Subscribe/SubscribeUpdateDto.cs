using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SubscribeUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public static Subscribe ToModel(SubscribeUpdateDto dto)
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
