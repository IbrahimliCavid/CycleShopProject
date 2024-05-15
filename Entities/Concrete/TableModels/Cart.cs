using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }
        public int UserId {  get; set; }
        public User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
