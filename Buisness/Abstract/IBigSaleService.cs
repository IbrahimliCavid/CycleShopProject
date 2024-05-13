using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IBigSaleService
    {
        IResult Add(BigSale entity);
        IResult Update(BigSale entity);
        IResult Delete(int id);
        IDataResult<BigSale> GetById(int id);
        IDataResult<List<BigSale>> GetAll();
    }
}
