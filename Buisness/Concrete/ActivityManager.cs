using Buisness.Abstract;
using Buisness.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
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

        public IResult Add(Activity entity)
        {
            _activityDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _activityDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(Activity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _activityDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<Activity>> GetAll()
        {
            return new SuccessDataResult<List<Activity>>(_activityDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Activity> GetById(int id)
        {
            return new SuccessDataResult<Activity>(_activityDal.GetById(id));
        }

    }
}
