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
    public class BestRacerManager : IBestRacerService
    {
       public readonly IBestRacerDal _bestRacerDal;

        public BestRacerManager(IBestRacerDal bestRacerDal)
        {
            _bestRacerDal = bestRacerDal;
        }

        public IResult Add(BestRacerCreateDto dto)
        {
            var model = BestRacerCreateDto.ToModel(dto);
            _bestRacerDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = BestRacerDto.ToModel(data);
            model.Deleted = id;
            _bestRacerDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(BestRacerUpdateDto dto)
        {
            var model = BestRacerUpdateDto.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _bestRacerDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<BestRacerDto>> GetAll()
        {
            var models = _bestRacerDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<BestRacerDto>>(BestRacerMapper.ToDto(models));
        }

        public IDataResult<BestRacerDto> GetById(int id)
        {
            var model = _bestRacerDal.GetById(id);
            return new SuccessDataResult<BestRacerDto>(BestRacerMapper.ToDto(model));
        }

      
    }
}
