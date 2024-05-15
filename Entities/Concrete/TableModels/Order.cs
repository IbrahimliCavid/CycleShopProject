using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Order : BaseEntity
    {
        public int CartId { get; set; }
        public int? ShippingAdressId { get; set; } = null;
        public decimal SubTotal { get; set; }
        public float Delivery { get; set; }
        public float Commision { get; set; }
        public float GrandTotal { get; set; }
        public bool IsDelivery { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ShippingAdress ShippingAdress { get; set; }
    }
}
