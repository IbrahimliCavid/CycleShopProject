using Buisness.BaseMessage;
using Core.DefaultValues;
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
    public class BestRacerValidation : AbstractValidator<BestRacer>
    {
        public BestRacerValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

            RuleFor(x => x.Info)
               .NotEmpty()
               .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
               .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE);


            RuleFor(x => x.FacebookLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);

            RuleFor(x => x.InstagramLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
               .Must(BeUniqeInstagram)
              .WithMessage(UIMessage.DEFAULT_ERROR_DUBLICATE_DATA)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
               .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);

            RuleFor(x => x.TwitterLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);

            RuleFor(x => x.EmailLink)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(150)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE);


            RuleFor(x => x.ImgUrl)
              .NotEmpty()
              .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(200)
              .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_200_MESSAGE);
        }

        private bool BeUniqeFacebook(string socialLink)
        {
            BestRacerDal _bestRacerDal = new();
            var data = _bestRacerDal.GetAll(x => x.FacebookLink == socialLink && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }

        private bool BeUniqeInstagram(string socialLink)
        {
            BestRacerDal _bestRacerDal = new();
            var data = _bestRacerDal.GetAll(x => x.InstagramLink == socialLink && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }

        private bool BeUniqeTwitter(string socialLink)
        {
            BestRacerDal _bestRacerDal = new();
            var data = _bestRacerDal.GetAll(x => x.TwitterLink == socialLink && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }

        private bool BeUniqeEmail(string socialLink)
        {
            BestRacerDal _bestRacerDal = new();
            var data = _bestRacerDal.GetAll(x => x.EmailLink == socialLink && x.Deleted == 0);
            if (data.Count() != 0) return false;
            return true;
        }
    }



}
