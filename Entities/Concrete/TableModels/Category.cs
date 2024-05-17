using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Cycles = new HashSet<Cycle>();
        }
        public string Name { get; set; }
        public ICollection<Cycle> Cycles { get; set; }
    }
}
