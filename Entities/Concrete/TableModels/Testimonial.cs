using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Feedback { get; set; }
    }
}
