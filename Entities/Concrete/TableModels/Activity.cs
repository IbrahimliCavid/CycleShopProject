using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Activity : BaseEntity
    {
        public string ActivityInfo { get; set; }
        public bool IsHomePage {  get; set; }
    }
}
