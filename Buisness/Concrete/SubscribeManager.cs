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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;
        private readonly IValidator<Subscribe> _validator;

        public SubscribeManager(ISubscribeDal subscribeDal, IValidator<Subscribe> validator)
        {
            _subscribeDal = subscribeDal;
            _validator = validator;
        }

        public IResult Add(SubscribeCreateDto dto)
        {
            var model = SubscribeMapper.ToModel(dto);
            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid || !BeUniqe(model))
            {
                return new ErrorResult(errorMessage);
            }
            _subscribeDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _subscribeDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(SubscribeUpdateDto dto)
        {
            var model = SubscribeMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid || !BeUniqe(model))
            {
                return new ErrorResult(errorMessage);
            }
            _subscribeDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<SubscribeDto>> GetAll()
        {
            var models = _subscribeDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<SubscribeDto>>(SubscribeMapper.ToDto(models));
        }

        public IDataResult<Subscribe> GetById(int id)
        {
            return new SuccessDataResult<Subscribe>(_subscribeDal.GetById(id));
        }

        private bool BeUniqe(Subscribe subscribe)
        {
            SubscribeDal _cycleDal = new SubscribeDal();
            var data = _cycleDal.GetAll(x => x.Email == subscribe.Email && x.Deleted == 0 && x.Id != subscribe.Id);
            return !data.Any();
        }
    }
}
