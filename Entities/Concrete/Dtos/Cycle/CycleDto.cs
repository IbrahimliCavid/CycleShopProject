using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CycleDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public short Count { get; set; }

        public double Price { get; set; }

        public  double NewPrice
        {
            get
            {
                return Price * (100 - PrecentOfDiscount) / 100; ;
            }
            set { }
        }
        public bool IsHomePage { get; set; }
        public bool IsTrend { get; set; }
        public float PrecentOfDiscount { get; set; }

        public byte StarRating { get; set; }

        public string CategoryName {  get; set; }

       
    }
}
