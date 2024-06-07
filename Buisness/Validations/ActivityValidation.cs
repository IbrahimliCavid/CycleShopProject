using Buisness.BaseMessage;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Validations
{
    public class ActivityValidation : AbstractValidator<Activity>
    {
        public ActivityValidation()
        {
            RuleFor(x => x.ActivityInfo)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Activity information"))
               .MaximumLength(2000)
               .WithMessage(UIMessage.GetMaxLengthMessage(2000, "Activity information"))
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);
            

        }

    

      


    }
}
