using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IServiceService
    {
        IResult Add(Service entity);
        IResult Update(Service entity);
        IResult Delete(int id);
        IDataResult<Service> GetById(int id);
        IDataResult<List<Service>> GetAll();
    }
}
