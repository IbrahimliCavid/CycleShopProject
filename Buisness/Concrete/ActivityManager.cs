using Buisness.Abstract;
using Core.Results.Abstract;
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
        ActivityDal _activityDal = new ActivityDal();
        public IResult Add(Activity activity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Activity activity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Activity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Activity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
