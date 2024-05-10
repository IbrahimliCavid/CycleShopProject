using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
