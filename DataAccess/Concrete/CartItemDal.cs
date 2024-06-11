using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.Dtos;

using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CartItemDal : BaseRepository<CartItem, ApplicationDbContext>, ICartItemDal
    {
        private readonly ApplicationDbContext _context;
        public CartItemDal()
        {

        }

        public CartItemDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartItemDto> GetCartWithCartItems()
        {
            var result = from cartItem in _context.CartItems
                         where cartItem.Deleted == 0
                         join cart in _context.Carts
                         on cartItem.CartId equals cart.Id
                         where cart.Deleted == 0
                         select new CartItemDto()
                         {
                             Id = cartItem.Id,
                             CartId = cartItem.CartId,
                             CycleId = cartItem.CycleId,
                             Quantity = cartItem.Quantity,
                             Price = cartItem.Cycle.Price,
                             NewPrice = cartItem.Cycle.NewPrice,
                             ImgUrl = cartItem.Cycle.ImgUrl,
                             StarRating = cartItem.Cycle.StarRating,
                             UserId = cartItem.Cart.UserId
                         };
            return result.ToList();

        }
    }
}
