using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public static Category ToModel(CategoryCreateDto dto)
        {
            Category category = new()
            {
                Name = dto.Name,
            };
            return category;
        }
    }
}
