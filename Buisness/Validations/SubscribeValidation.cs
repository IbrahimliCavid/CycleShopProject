using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class SubscribeValidation : AbstractValidator<Subscribe>
    {
        public SubscribeValidation()
        {
            RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
             .MinimumLength(3)
             .WithMessage(UIMessage.GetMinLengthMessage(3, "Email"))
             .MaximumLength(100)
             .WithMessage(UIMessage.GetMaxLengthMessage(100, "Email"))
             .EmailAddress()
             .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS);
        }

       
    }



}
