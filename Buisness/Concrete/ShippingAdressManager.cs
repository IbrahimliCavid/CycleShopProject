using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class ShippingAdressManager : IShippingAdressService
    {
        private readonly IShippingAdressDal _shippingAdressDal;
        private readonly IValidator<ShippingAdress> _validator;

        public ShippingAdressManager(IShippingAdressDal bigSaleDal, IValidator<ShippingAdress> validator)
        {
            _shippingAdressDal = bigSaleDal;
            _validator = validator;
        }

        public IResult Add(ShippingAdressCreateDto dto)
        {
            var model = ShippingAdressMapper.ToModel(dto);

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
            _shippingAdressDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _shippingAdressDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(ShippingAdressUpdateDto dto)
        {
            var model = ShippingAdressMapper.ToModel(dto);
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
            _shippingAdressDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<ShippingAdressDto>> GetShippingAdressWithUser()
        {
           
            return new SuccessDataResult<List<ShippingAdressDto>>(_shippingAdressDal.GetUserNameForShippingAdress());
        }

        public IDataResult<ShippingAdress> GetById(int id)
        {
            return new SuccessDataResult<ShippingAdress>(_shippingAdressDal.GetById(id));
        }

    
    }
}
