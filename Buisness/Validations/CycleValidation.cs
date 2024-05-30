using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class CycleValidation : AbstractValidator<Cycle>
    {
        public CycleValidation()
        {
            RuleFor(x => x.Model)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(100)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);




            RuleFor(x => x.Price)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);


            RuleFor(x => x.CategoryId)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Count)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);


        }

       
    }
}
