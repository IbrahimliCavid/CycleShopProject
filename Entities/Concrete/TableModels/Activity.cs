using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Activity : BaseEntity
    {
        public int AboutId { get; set; }
        public string ActivityInfo { get; set; }
        public bool IsActive {  get; set; }
        public virtual About About { get; set; }
    }
}
