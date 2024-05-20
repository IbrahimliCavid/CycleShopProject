using Buisness.BaseMessage;
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
             .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
             .MaximumLength(100)
             .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE)
             .EmailAddress()
             .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS);
        }
    }



}
