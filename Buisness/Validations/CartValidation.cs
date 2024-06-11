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
    public class CartValidation : AbstractValidator<Cart>
    {
        public CartValidation()
        {
            RuleFor(x=>x.UserId)
                .NotEmpty()
                .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);
        }
    }
}
