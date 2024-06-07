using Buisness.BaseMessage;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UIMessage.GetMinLengthMessage(3,"Description"))
                .MaximumLength(2000)
                .WithMessage(UIMessage.GetMaxLengthMessage(2000, "Description"))
                .NotEmpty()
                .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);


        }
    }
}
