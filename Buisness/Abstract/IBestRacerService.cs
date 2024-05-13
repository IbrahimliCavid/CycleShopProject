using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IBestRacerService
    {
        IResult Add(BestRacer entity);
        IResult Delete(int id);
        IResult Update(BestRacer entity);

        IDataResult<BestRacer> GetById(int id);
        IDataResult<List<BestRacer>> GetAll();
    }
}
