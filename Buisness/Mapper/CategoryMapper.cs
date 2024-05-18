using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class CategoryMapper
    {
        public static CategoryDto ToDto(Category model)
        {
            CategoryDto dto = new()
            {
                Id = model.Id,
                Name = model.Name
            };
            return dto;
        }

        public static List<CategoryDto> ToDto(List<Category> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
