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

        public static CategoryUpdateDto ToUpdateDto(Category model)
        {
            CategoryUpdateDto dto = new()
            {
                Id = model.Id,
                Name = model.Name
            };
            return dto;
        }

        public static List<CategoryUpdateDto> ToUpdateDto(List<Category> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }
        public static Category ToModel(CategoryCreateDto dto)
        {
            Category category = new()
            {
                Name = dto.Name,
            };
            return category;
        }

        public static Category ToModel(CategoryDto dto)
        {
            Category category = new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return category;
        }
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
