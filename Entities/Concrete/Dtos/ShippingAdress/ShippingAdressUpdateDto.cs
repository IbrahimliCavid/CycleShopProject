namespace Entities.Concrete.Dtos
{
    public class ShippingAdressUpdateDto
    {
        public int Id { get; set; }
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
    }
}
