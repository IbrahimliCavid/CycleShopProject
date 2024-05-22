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
             .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
             .MaximumLength(100)
             .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE)
             .EmailAddress()
             .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS)
             .Must(BeUniqe)
             .WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);
        }

        private bool BeUniqe(string email)
        {
            SubscribeDal _cycleDal = new SubscribeDal();
            var data = _cycleDal.GetAll(x => x.Email == email && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }
    }



}
