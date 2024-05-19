using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
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

        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }

        public IResult Add(ActivityCreateDto dto)
        {
            var model = ActivityMapper.ToModel(dto);
            _activityDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = ActivityMapper.ToModel(data);
                model.Deleted = id;
            _activityDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(ActivityUpdateDto dto)
        {
            var model = ActivityMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _activityDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<ActivityDto>> GetAll()
        {
            var models = _activityDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<ActivityDto>>(ActivityMapper.ToDto(models));
        }

        public IDataResult<ActivityDto> GetById(int id)
        {
            var model = _activityDal.GetById(id);

            return new SuccessDataResult<ActivityDto>(ActivityMapper.ToDto(model));
        }

    }
}
