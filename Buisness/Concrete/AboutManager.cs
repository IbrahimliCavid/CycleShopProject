using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IValidator<About> validator)
        {
            _aboutDal = aboutDal;

            _validator = validator;
        }
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutMapper.ToModel(dto); 

            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _aboutDal.Add(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }


        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutMapper.ToModel(dto);
           
            model.LastUpdateDate = DateTime.Now;
           
            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _aboutDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<AboutDto>> GetAll()
        {

            var models = _aboutDal.GetAll(x => x.Deleted == 0);
           
            return new SuccessDataResult<List<AboutDto>>(AboutMapper.ToDto(models));
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetById(id));
        }

      
    }
}
