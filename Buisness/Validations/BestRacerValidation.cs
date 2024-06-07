

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
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Name"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "Name"));

            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Surname"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "Surname"));

            RuleFor(x => x.Info)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Information"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "Information"));

            RuleFor(x => x.FacebookLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "FacebookLink"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "FacebookLink"));

            RuleFor(x => x.InstagramLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "InstagramLink"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "InstagramLink"));

            RuleFor(x => x.LinkedinLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
             .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "LinkedinLink"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "LinkedinLink"));
        }
    }
}
