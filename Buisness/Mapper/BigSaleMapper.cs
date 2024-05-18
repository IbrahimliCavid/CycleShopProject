using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class BigSaleMapper
    {
        public static BigSaleDto ToDto(BigSale model)
        {
            BigSaleDto dto = new()
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
            };
            return dto;
        }

        public static List<BigSaleDto> ToDto(List<BigSale> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
