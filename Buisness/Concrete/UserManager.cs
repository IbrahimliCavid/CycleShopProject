using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(UserCreateDto dto)
        {
            var model = UserMapper.ToModel(dto);
            _userDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = UserMapper.ToModel(data);
            model.Deleted = id;
            _userDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);

        }
        public IResult Update(UserUpdateDto dto)
        {
            var model = UserMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _userDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<UserDto>> GetAll()
        {
            var models = _userDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<UserDto>>(UserMapper.ToDto(models));
        }

        public IDataResult<UserDto> GetById(int id)
        {
            var model = _userDal.GetById(id);
            return new SuccessDataResult<UserDto>(UserMapper.ToDto(model));
        }

    }
}
