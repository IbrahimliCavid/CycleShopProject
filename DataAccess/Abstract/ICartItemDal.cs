using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;

using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartItemDal : IBaseRepository<CartItem>
    {
        List<CartItemDto> GetCartWithCartItems();
    }
}
