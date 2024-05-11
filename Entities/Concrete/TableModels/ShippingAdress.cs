using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class ShippingAdress : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
