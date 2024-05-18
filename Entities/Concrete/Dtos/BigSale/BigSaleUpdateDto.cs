using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BigSaleUpdateDto
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public static BigSale ToModel(BigSaleUpdateDto dto)
        {
            BigSale bigSale = new()
            {
                Id = dto.Id,
                ImgUrl = dto.ImgUrl,
            };
            return bigSale;
        }
    }
}
