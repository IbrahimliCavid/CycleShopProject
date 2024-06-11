using Core.Entities.Abstract;
using Entities.Concrete.MemberShip;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {
       
        public int UserId {  get; set; }
        public int CycleId {  get; set; }
        public ApplicationUser User { get; set; }
        public  Cycle Cycle { get; set; }
    }
}
