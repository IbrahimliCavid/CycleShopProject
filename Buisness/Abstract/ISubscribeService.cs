using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ISubscribeService
    {
        IResult Add(Subscribe entity);
        IResult Update(Subscribe entity);
        IResult Delete(int id);
        IDataResult<Subscribe> GetById(int id);
        IDataResult<List<Subscribe>> GetAll();
    }
}
