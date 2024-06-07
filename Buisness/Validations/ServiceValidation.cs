using Buisness.BaseMessage;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {

            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Title"))
               .MaximumLength(200)
               .WithMessage(UIMessage.GetMaxLengthMessage(200, "Title"));


            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Description"))
               .MaximumLength(500)
               .WithMessage(UIMessage.GetMaxLengthMessage(500, "Description"));
        }
    }



}
