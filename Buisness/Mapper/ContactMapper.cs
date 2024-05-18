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
    }
}
