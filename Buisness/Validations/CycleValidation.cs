using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class CycleValidation : AbstractValidator<Cycle>
    {
        public CycleValidation(bool isCreate)
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(100)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);


            if (isCreate)
            {
                RuleFor(x => x.Name)
                    .Must(BeUniqe)
                    .WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);
            }



            RuleFor(x => x.Price)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);


            RuleFor(x => x.CategoryId)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Count)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

            RuleFor(x => x.PrecentOfDiscount)
             .NotEmpty()
             .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

        }

        private bool BeUniqe(string name)
        {
            CycleDal _cycleDal = new CycleDal();
            var data = _cycleDal.GetAll(x => x.Name == name && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }
    }
}
