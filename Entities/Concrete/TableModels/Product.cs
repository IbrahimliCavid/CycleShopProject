using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Product : BaseEntity
    {

        public Product()
        {
            Carts = new HashSet<Cart>();
        }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public short Price { get; set; }
        public byte PrecentOfDiscount { get; set; }
        public short NewPrice { get; set; }
        public byte StarRating { get; set; }
        public int ShopId { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
    }
}
