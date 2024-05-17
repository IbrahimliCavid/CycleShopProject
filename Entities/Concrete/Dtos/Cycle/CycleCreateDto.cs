using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CycleCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public short Count { get; set; }
        public double Price { get; set; }
        public float PrecentOfDiscount { get; set; }
        public bool IsHomePage { get; set; }
        public byte StarRating { get; set; }
        

        public static Cycle ToCycle(CycleCreateDto dto)
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
