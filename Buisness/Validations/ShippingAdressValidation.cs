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
    public class ShippingAdressValidation : AbstractValidator<ShippingAdress>
    {
        public ShippingAdressValidation()
        {

            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Name"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Name"));


            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Last name"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Last name"));


            RuleFor(x => x.State)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "State"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "State"));


            RuleFor(x => x.PostalCode)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Postal code"))
               .MaximumLength(10)
               .WithMessage(UIMessage.GetMaxLengthMessage(10, "Postal code"));


            RuleFor(x => x.City)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "City"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "City"));


            RuleFor(x => x.Country)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Country"))
               .MaximumLength(100)
               .WithMessage(UIMessage.GetMaxLengthMessage(100, "Country"));


            RuleFor(x => x.Adress)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Adress"))
               .MaximumLength(400)
               .WithMessage(UIMessage.GetMaxLengthMessage(400, "Adress"));


            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Email"))
               .MaximumLength(150)
               .WithMessage(UIMessage.GetMaxLengthMessage(150, "Email"))
               .EmailAddress()
               .WithMessage(UIMessage.DEFAULT_INVALID_EMAIL_ADRESS);


            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.GetMinLengthMessage(3, "Phono number"))
               .MaximumLength(13)
               .WithMessage(UIMessage.GetMaxLengthMessage(13, "Phono number"));


        }
    }
}
