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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _aboutDal;

        public ServiceManager(IServiceDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(ServiceCreateDto dto)
        {
            var model = ServiceMapper.ToModel(dto);
            _aboutDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = ServiceMapper.ToModel(data);
            model.Deleted = id;
            _aboutDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(ServiceUpdateDto dto)
        {
            var model = ServiceMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _aboutDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<ServiceDto>> GetAll()
        {
            var models = _aboutDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<ServiceDto>>(ServiceMapper.ToDto(models));
        }

        public IDataResult<ServiceDto> GetById(int id)
        {
            var model = _aboutDal.GetById(id);
            return new SuccessDataResult<ServiceDto>(ServiceMapper.ToDto(model));
        }

    }
}
