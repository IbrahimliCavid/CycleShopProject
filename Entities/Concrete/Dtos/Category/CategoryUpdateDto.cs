using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public static Category ToModel(CategoryUpdateDto dto)
        {
            Category category = new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return category;
        }
    }
}
