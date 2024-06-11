using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public int CycleId { get; set; }
        public byte Quantity { get; set; }
        public Cart Cart { get; set; }
        public Cycle Cycle {  get; set; }
    }
}
