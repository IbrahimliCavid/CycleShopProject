using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
    }
}
