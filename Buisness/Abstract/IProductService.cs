using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductService
    {
        IResult Add(Product entity);
        IResult Update(Product entity);
        IResult Delete(int id);
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetProductWithCycleCategoryId();
    }
}
