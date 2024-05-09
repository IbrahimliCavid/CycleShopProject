using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
