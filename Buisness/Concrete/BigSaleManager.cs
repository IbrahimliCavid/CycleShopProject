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
    public class BigSaleManager : IBigSaleService
    {
        private readonly IBigSaleDal _bigSaleDal;
        private readonly IValidator<BigSale> _validator;

        public BigSaleManager(IBigSaleDal bigSaleDal, IValidator<BigSale> validator)
        {
            _bigSaleDal = bigSaleDal;
            _validator = validator;
        }

        public IResult Add(BigSaleCreateDto dto)
        {
            var model = BigSaleMapper.ToModel(dto);
            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _bigSaleDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = BigSaleMapper.ToModel(data);
            model.Deleted = id;
            _bigSaleDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
            
        }
        public IResult Update(BigSaleUpdateDto dto)
        {
            var model = BigSaleMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;

            var validator = _validator.Validate(model);

            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _bigSaleDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<BigSaleDto>> GetAll()
        {
            var models = _bigSaleDal.GetAll(x => x.Deleted == 0);
              
            return new  SuccessDataResult<List<BigSaleDto>>(BigSaleMapper.ToDto(models));
        }

        public IDataResult<BigSaleUpdateDto> GetById(int id)
        {
            var model = _bigSaleDal.GetById(id);
            
            return new SuccessDataResult<BigSaleUpdateDto>(BigSaleMapper.ToUpdateDto(model));
        }

     
    }
}
