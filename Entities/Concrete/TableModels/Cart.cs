using Core.Entities.Abstract;
using Entities.Concrete.MemberShip;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {

        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public int UserId {  get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
