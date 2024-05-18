using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Feedback { get; set; }
        public static Testimonial ToModel(TestimonialDto dto)
        {
            Testimonial testimonial = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Feedback = dto.Feedback,
            };
            return testimonial;
        }
    }
}
