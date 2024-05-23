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
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(2000)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);
               //.Must(BeUniqe)
               //.WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);
               
        }

        private bool BeUniqe(string info)
        {
            ActivityDal _cycleDal = new ActivityDal();
            var data = _cycleDal.GetAll(x => x.ActivityInfo == info && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }

    }
}
