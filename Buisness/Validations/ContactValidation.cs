using Buisness.BaseMessage;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Name"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Name"));

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Email"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Email"))
               .EmailAddress()
               .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS);

            RuleFor(x => x.Message)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Message"))
               .MaximumLength(2000)
               .WithMessage(UIMessage.GetMaxLengthMessage(2000, "Message"));
        }
    }

 

}
