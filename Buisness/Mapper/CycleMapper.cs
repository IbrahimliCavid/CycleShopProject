using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class CycleMapper
    {
        public static CycleDto ToDto(Cycle model)
        {
            CycleDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                ImgUrl = model.ImgUrl,
                StarRating = model.StarRating,
                Count = model.Count,
                Price = model.Price,
                PrecentOfDiscount = model.PrecentOfDiscount,
                IsHomePage = model.IsHomePage
            };
            return dto;
        }
    }
}
