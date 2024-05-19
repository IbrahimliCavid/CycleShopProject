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

        public static Testimonial ToModel(TestimonialCreateDto dto)
        {
            Testimonial testimonial = new()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Feedback = dto.Feedback,
            };
            return testimonial;
        }

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

        public static Testimonial ToModel(TestimonialUpdateDto dto)
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
