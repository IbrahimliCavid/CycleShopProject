using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Order : BaseEntity
    {
        public int CartId { get; set; }
        public int ShippingAdressId { get; set; }
        public int SubTotal { get; set; }
        public short Delivery { get; set; }
        public short Commision { get; set; }
        public int GrandTotal { get; set; }
        public bool IsDelivery { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ShippingAdress ShippingAdress { get; set; }
    }
}
