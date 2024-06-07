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
              .WithMessage(UIMessage.GetMinLengthMessage(3, "Model"))
              .MaximumLength(100)
              .WithMessage(UIMessage.GetMaxLengthMessage(100, "Model"));




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
