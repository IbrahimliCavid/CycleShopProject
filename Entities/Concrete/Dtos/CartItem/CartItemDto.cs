using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int CycleId { get; set; }
        public byte Quantity { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
        public float PrecentOfDiscount { get; set; }
        public double NewPrice
        {
            get
            {
                return Price * (100 - PrecentOfDiscount) / 100; ;
            }
            set { }
        }
        public byte StarRating { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
    }
}
