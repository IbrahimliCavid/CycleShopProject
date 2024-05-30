using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.MemberShip
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
    }
}
