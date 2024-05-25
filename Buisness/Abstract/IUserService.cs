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
    public interface IUserService 
    {
        IResult Add(UserCreateDto dto);
        IResult Update(UserUpdateDto dto);
        IResult Delete(int id);
        IDataResult<User> GetById(int id);
        IDataResult<List<UserDto>> GetAll();
    }
}
