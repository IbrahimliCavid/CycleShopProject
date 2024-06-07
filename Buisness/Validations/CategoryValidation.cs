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
                .MinimumLength(3)
                .WithMessage(UIMessage.GetMinLengthMessage(3, "Category name"))
                .MaximumLength(100)
                .WithMessage(UIMessage.GetMaxLengthMessage(100, "Category name"));

        }

      
    }
}
