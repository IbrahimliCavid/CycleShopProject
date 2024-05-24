using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Buisness.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(100)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE)
              .Must(BeUniqeName)
              .WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(100)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE)
               .EmailAddress()
               .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS)
               .Must(BeUniqeEmail)
               .WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(6)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_6_MESSAGE)
               .MaximumLength(100)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE)
               .Matches(@"[A-Z]+")
               .WithMessage(UIMessage.PASSWORD_NOT_CONTAIN_UPPERCASE)
               .Matches(@"[a-z]+")
               .WithMessage(UIMessage.PASSWORD_NOT_CONTAIN_LOWERCASE)
               .Matches(@"[0-9]+")
               .WithMessage(UIMessage.PASSWORD_NOT_CONTAIN_NUMBER);
               //.Matches(@"[\!\@\#]+")
               //.WithMessage("");


        }
        private bool BeUniqeEmail(User user, string email)
        {
            UserDal _cycleDal = new UserDal();
            var data = _cycleDal.GetAll(x => x.Email == email && x.Deleted == 0 && x.Id != user.Id);
            return !data.Any();
        }
        private bool BeUniqeName(User user, string name)
        {
            UserDal _cycleDal = new UserDal();
            var data = _cycleDal.GetAll(x => x.UserName == name && x.Deleted == 0 && x.Id != user.Id);
            return !data.Any();
        }


    }



}
