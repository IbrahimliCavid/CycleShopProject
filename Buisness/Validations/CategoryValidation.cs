using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Buisness.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
                //.Must(BeUniqe)
                //.WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA)
                .MinimumLength(3)
                .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

        }

        private bool BeUniqe(string name)
        {
            CategoryDal _categoryDal = new();
            var data = _categoryDal.GetAll(x => x.Name == name && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }
    }
}
