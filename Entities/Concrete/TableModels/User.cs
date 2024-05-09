using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class User : BaseEntity
    {
        public User()
        {
            ShippingAdresses = new HashSet<ShippingAdress>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<ShippingAdress> ShippingAdresses { get; set; }
    }
}
