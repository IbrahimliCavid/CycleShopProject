using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CycleCreateDto
    {
    
        public string Model { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public short Count { get; set; }
        public double Price { get; set; }
        public float PrecentOfDiscount { get; set; }
        public bool IsHomePage { get; set; }
        public bool IsTrend { get; set; }
        public byte StarRating { get; set; }
        public string CategoryName {  get; set; }
    }
}
