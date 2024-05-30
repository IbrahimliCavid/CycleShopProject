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
                Model = model.Model,
                CategoryId = model.CategoryId,
                ImgUrl = model.ImgUrl,
                StarRating = model.StarRating,
                Count = model.Count,
                Price = model.Price,
                PrecentOfDiscount = model.PrecentOfDiscount,
                IsHomePage = model.IsHomePage,
                IsTrend = model.IsTrend
            };
            return dto;
        }

        public static CycleUpdateDto ToUpdateDto(Cycle model)
        {
            CycleUpdateDto dto = new()
            {
                Id = model.Id,
                Model = model.Model,
                CategoryId = model.CategoryId,
                ImgUrl = model.ImgUrl,
                StarRating = model.StarRating,
                Count = model.Count,
                Price = model.Price,
                PrecentOfDiscount = model.PrecentOfDiscount,
                IsHomePage = model.IsHomePage,
                IsTrend = model.IsTrend
            };
            return dto;
        }

        public static Cycle ToModel(CycleCreateDto dto)
        {
            Cycle cycle = new()
            {

                Model = dto.Model,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage,
                IsTrend = dto.IsTrend
            };
            return cycle;
        }

        public static Cycle ToModel(CycleDto dto)
        {
            Cycle cycle = new Cycle()
            {
                Id = dto.Id,
                Model = dto.Model,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage,
                                IsTrend = dto.IsTrend

            };
            return cycle;
        }

        public static Cycle ToModel(CycleUpdateDto dto)
        {
            Cycle cycle = new()
            {

                Id = dto.Id,
                Model = dto.Model,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage,
                IsTrend = dto.IsTrend
            };
            return cycle;
        }
    }
}
