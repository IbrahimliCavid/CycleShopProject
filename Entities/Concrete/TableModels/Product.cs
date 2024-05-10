using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.TableModels
{
    public class Product : BaseEntity
    {
        [NotMapped]
        private double _price = 0;
        public Product()
        {
            Carts = new HashSet<Cart>();
        }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public double Price
        {
            get
            {
                var newPrice = _price * (100 - PrecentOfDiscount) / 100;
                return newPrice;
            } 
            set
            {
                _price = value;
            }
        }
        public byte PrecentOfDiscount { get; set; } = 0;
        [NotMapped]
        public byte StarRating { get; set; }
        public int ShopId { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
    }
}
