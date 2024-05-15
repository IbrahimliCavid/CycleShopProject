using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.TableModels
{
    public class Product : BaseEntity
    {
        //[NotMapped]
        //private double _price;
        public Product()
        {
            Carts = new HashSet<Cart>();
        }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        //public double Price {
        //    get 
        //    {
        //        return _price;
        //    } 
        //    set {
        //        _price = Price;
        //    } 
        //}
        public double Price { get; set; }
        [NotMapped]
        public double NewPrice
        {

            get
            {
                return Price * (100 - PrecentOfDiscount) / 100; ;
            }

        }
        public bool IsHomePage { get; set; }
        public float PrecentOfDiscount { get; set; }
   
        public byte StarRating { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual CycleCategory Category { get; set; }
    }
}
