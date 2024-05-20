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
    public  class BigSaleValidation : AbstractValidator<BigSale>
    {
        public BigSaleValidation()
        {
            RuleFor(x => x.ImgUrl)
                .NotEmpty()
                .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
                .MinimumLength(10)
                .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_10_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);
        }
    }
}
