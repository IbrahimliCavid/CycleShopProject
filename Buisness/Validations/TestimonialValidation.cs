using Buisness.BaseMessage;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class TestimonialValidation : AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.GetMinLengthMessage(3, "Name"))
              .MaximumLength(100)
              .WithMessage(UIMessage.GetMaxLengthMessage(100, "Title"));

            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Surname"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Surname"));

              RuleFor(x => x.Feedback)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Feedback"))
               .MaximumLength(2000)
               .WithMessage(UIMessage.GetMaxLengthMessage(2000, "Feedback"));
        }
    }



}
