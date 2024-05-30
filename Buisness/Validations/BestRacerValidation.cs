

using Buisness.BaseMessage;
using Core.DefaultValues;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class BestRacerValidation : AbstractValidator<BestRacer>
    {
        public BestRacerValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

            RuleFor(x => x.Info)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE);

            RuleFor(x => x.FacebookLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);

            RuleFor(x => x.InstagramLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);

            RuleFor(x => x.LinkedinLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);
        }
    }
}
