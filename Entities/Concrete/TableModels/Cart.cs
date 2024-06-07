using Core.Entities.Abstract;
using Entities.Concrete.MemberShip;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Cycles = new HashSet<Cycle>();
        }
        public int UserId {  get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<Cycle> Cycles { get; set; }
    }
}
