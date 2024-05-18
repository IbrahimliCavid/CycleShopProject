using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BigSaleCreateDto
    {
        public string ImgUrl { get; set; }
        public static BigSale ToModel(BigSaleCreateDto dto)
        {
            BigSale bigSale = new()
            {
                ImgUrl = dto.ImgUrl,
            };
            return bigSale;
        }
    }
}
