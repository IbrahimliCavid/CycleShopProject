using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ShippingAdressDal : BaseRepository<ShippingAdress, ApplicationDbContext>, IShippingAdressDal
    {
        private readonly ApplicationDbContext _context;

        public ShippingAdressDal()
        {

        }
        public ShippingAdressDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ShippingAdressDto> GetUserNameForShippingAdress()
        {
            var result = from shipping in _context.ShippingAdresses
                         where shipping.Deleted == 0
                         join user in _context.Users
                         on shipping.UserId equals user.Id
                         select new ShippingAdressDto
                         {
                             Id = user.Id,
                             FirstName = shipping.FirstName,
                             LastName = shipping.LastName,
                             PostalCode = shipping.PostalCode,
                             Adress = shipping.Adress,
                             Country = shipping.Country,
                             State = shipping.State,
                             City = shipping.City,
                             PhoneNumber = shipping.PhoneNumber,
                             Email = shipping.Email,
                             UserName = user.UserName
                         };

            return result.ToList();

        }

    }
}
