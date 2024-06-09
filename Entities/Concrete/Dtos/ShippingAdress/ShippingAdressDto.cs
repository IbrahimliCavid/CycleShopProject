using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ShippingAdressDto
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
        public string UserName { get; set; }
    }
}
