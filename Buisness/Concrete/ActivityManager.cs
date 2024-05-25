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
    public class ActivityManager : IActivityService
    {
       public readonly IActivityDal _activityDal;
        public readonly IValidator<Activity> _validator;

        public ActivityManager(IActivityDal activityDal, IValidator<Activity> validator)
        {
            _activityDal = activityDal;
            _validator = validator;
        }

        public IResult Add(ActivityCreateDto dto)
        {
            
            var model = ActivityMapper.ToModel(dto);
           
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
            
            _activityDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
           
                data.Deleted = id;
            _activityDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(ActivityUpdateDto dto)
        {
            var model = ActivityMapper.ToModel(dto);
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
            _activityDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<ActivityDto>> GetAll()
        {
            var models = _activityDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<ActivityDto>>(ActivityMapper.ToDto(models));
        }

        public IDataResult<Activity> GetById(int id)
        {
            return new SuccessDataResult<Activity>(_activityDal.GetById(id));
        }

    }
}
