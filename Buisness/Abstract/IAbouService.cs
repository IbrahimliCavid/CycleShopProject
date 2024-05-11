using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAbouService
    {
        IResult Add(About entity);
        IResult Update(About entity);
        IResult Delete(About entity);
        IDataResult<About> GetById(int id);
        IDataResult<List<About>> GetAll();
    }
}
