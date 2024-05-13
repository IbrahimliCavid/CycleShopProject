using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IActivityService
    {
        
        IResult Add(Activity activity);
        IResult Delete(int id);
        IResult Update(Activity activity);
        IDataResult<Activity> GetById(int id);
        IDataResult<List<Activity>> GetAll();
    }
}


