﻿using Entities.Concrete.Dtos;
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

        public static CycleUpdateDto ToUpdateDto(Cycle model)
        {
            CycleUpdateDto dto = new()
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

        public static Cycle ToModel(CycleCreateDto dto)
        {
            Cycle cycle = new()
            {

                Name = dto.Name,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage
            };
            return cycle;
        }

        public static Cycle ToModel(CycleDto dto)
        {
            Cycle cycle = new Cycle()
            {
                Id = dto.Id,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage
            };
            return cycle;
        }

        public static Cycle ToModel(CycleUpdateDto dto)
        {
            Cycle cycle = new()
            {

                Id = dto.Id,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                ImgUrl = dto.ImgUrl,
                StarRating = dto.StarRating,
                Count = dto.Count,
                Price = dto.Price,
                PrecentOfDiscount = dto.PrecentOfDiscount,
                IsHomePage = dto.IsHomePage
            };
            return cycle;
        }
    }
}
