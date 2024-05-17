using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category cycleCategory);
        IResult Delete(int id);
        IResult Update(Category cycleCategory);

        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
    }
}
