using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class CycleCategory : BaseEntity
    {
        public CycleCategory()
        {
            Products = new HashSet<Cycle>();
        }
        public string Name { get; set; }
        public ICollection<Cycle> Products { get; set; }
    }
}
