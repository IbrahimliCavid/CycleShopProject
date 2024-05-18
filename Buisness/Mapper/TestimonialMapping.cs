using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Buisness.Mapper
{
    public class TestimonialMapping
    {
        public static TestimonialDto ToDto(Testimonial model)
        {
            TestimonialDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Feedback = model.Feedback,
            };
            return dto;
        }

        public static List<TestimonialDto> ToDto(List<Testimonial> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
