using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
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
        public readonly IValidator<BestRacer> _validator;

        public BestRacerManager(IBestRacerDal bestRacerDal, IValidator<BestRacer> validator)
        {
            _bestRacerDal = bestRacerDal;
            _validator = validator;
        }

        public IResult Add(BestRacerCreateDto dto, out ErrorDataResult<string> error)
        {
            var model = BestRacerMapper.ToModel(dto);

            var validator = _validator.Validate(model);

            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    error = new ErrorDataResult<string>(item.PropertyName, item.ErrorMessage);
                    return error;
                }
            }

            error = null;
            _bestRacerDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = BestRacerMapper.ToModel(data);
            model.Deleted = id;
            _bestRacerDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(BestRacerUpdateDto dto, out ErrorDataResult<string> error)
        {
            var model = BestRacerMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;

            var validator = _validator.Validate(model);


            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    error = new ErrorDataResult<string>(item.PropertyName, item.ErrorMessage);
                    return error;
                }
            }

            error = null;
            _bestRacerDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<BestRacerDto>> GetAll()
        {
            var models = _bestRacerDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<BestRacerDto>>(BestRacerMapper.ToDto(models));
        }

        public IDataResult<BestRacerUpdateDto> GetById(int id)
        {
            var model = _bestRacerDal.GetById(id);
            return new SuccessDataResult<BestRacerUpdateDto>(BestRacerMapper.ToUpdateDto(model));
        }
    }
}
