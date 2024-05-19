using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class ContactMapper
    {
        public static ContactDto ToDto(Contact model)
        {
            ContactDto dto = new()
            {
                Id = model.Id,
                Name = model.Name
            };
            return dto;
        }

        public static List<ContactDto> ToDto(List<Contact> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
        public static Contact ToModel(ContactCreateDto dto)
        {
            Contact contact = new()
            {

                Name = dto.Name,
                Surname = dto.Surname,
                Message = dto.Message,
                IsAnswer = dto.IsAnswer
            };
            return contact;
        }

        public static Contact ToModel(ContactDto dto)
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
