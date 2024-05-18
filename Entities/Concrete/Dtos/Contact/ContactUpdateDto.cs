using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public bool IsAnswer { get; set; }
        public static Contact ToModel(ContactUpdateDto dto)
        {
            Contact contact = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Message = dto.Message,
                IsAnswer = dto.IsAnswer
            };
            return contact;
        }
    }
}
