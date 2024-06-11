using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICartService
    {
        IResult Add(Cart model);
        IResult Delete(int id);
        IResult Update(Cart model);

        IDataResult<Cart> GetById(int id);
        IDataResult<List<Cart>> GetAll();
    }
}
