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
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(200)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_200_MESSAGE);


            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(500)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_500_MESSAGE);

       
        }
    }



}
