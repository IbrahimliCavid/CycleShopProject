﻿using Buisness.Abstract;
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
    public class CycleManager : ICycleService
    {
        public readonly ICycleDal _prdouctDal;
        public readonly IValidator<Cycle> _validator;

        public CycleManager(ICycleDal prdouctDal, IValidator<Cycle> validator)
        {
            _prdouctDal = prdouctDal;
            _validator = validator;
        }

        public IResult Add(CycleCreateDto dto)
        {
            var model = CycleMapper.ToModel(dto);

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
            _prdouctDal.Add(model);
            return null;
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
            _prdouctDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }


        public IDataResult<CycleUpdateDto> GetById(int id)
        {
            var model = _prdouctDal.GetById(id);
            return new SuccessDataResult<CycleUpdateDto>(CycleMapper.ToUpdateDto(model));
        }

        public IDataResult<List<CycleDto>> GetProductWithCycleCategoryId()
        {
            return new SuccessDataResult<List<CycleDto>>(_prdouctDal.GetCycleWithCycleCategories());
        }
    }
}
