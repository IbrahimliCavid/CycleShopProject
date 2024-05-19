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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public IResult Add(SubscribeCreateDto dto)
        {
            var model = SubscribeMapper.ToModel(dto);
            _subscribeDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = SubscribeMapper.ToModel(data);
            model.Deleted = id;
            _subscribeDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(SubscribeUpdateDto dto)
        {
            var model = SubscribeMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _subscribeDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<SubscribeDto>> GetAll()
        {
            var models = _subscribeDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<SubscribeDto>>(SubscribeMapper.ToDto(models));
        }

        public IDataResult<SubscribeDto> GetById(int id)
        {
            var model = _subscribeDal.GetById(id);
            return new SuccessDataResult<SubscribeDto>(SubscribeMapper.ToDto(model));
        }

    }
}
