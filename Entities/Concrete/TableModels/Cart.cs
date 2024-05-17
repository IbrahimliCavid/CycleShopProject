using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Cycles = new HashSet<Cycle>();
        }
        public int UserId {  get; set; }
        public User User { get; set; }
        public virtual ICollection<Cycle> Cycles { get; set; }
    }
}
