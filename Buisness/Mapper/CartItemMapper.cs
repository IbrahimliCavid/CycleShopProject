using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapper
{
    public class CartItemMapper
    {
        public static CartItem ToModel(CartItemDto dto)
        {
            CartItem model = new()
            {
                Id = dto.Id,
               CartId = dto.CartId,
               CycleId = dto.CycleId,
               Quantity = dto.Quantity,
            };
            return model;
        }
    }
}
