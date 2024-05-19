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
    public class CycleManager : ICycleService
    {
        public readonly ICycleDal _prdouctDal;

        public CycleManager(ICycleDal prdouctDal)
        {
            _prdouctDal = prdouctDal;
        }

        public IResult Add(CycleCreateDto dto)
        {
            var model = CycleMapper.ToModel(dto);
            _prdouctDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = CycleMapper.ToModel(data);
            model.Deleted = id;
            _prdouctDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(CycleUpdateDto dto)
        {
            var model = CycleMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _prdouctDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

    
        public IDataResult<CycleDto> GetById(int id)
        {
            var model = _prdouctDal.GetById(id);
            return new SuccessDataResult<CycleDto>(CycleMapper.ToDto(model));
        }

        public IDataResult<List<CycleDto>> GetProductWithCycleCategoryId()
        {
            return new SuccessDataResult<List<CycleDto>>(_prdouctDal.GetCycleWithCycleCategories());
        }
    }
}
