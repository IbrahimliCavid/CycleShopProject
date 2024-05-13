using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IUserService 
    {
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(int id);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
    }
}
