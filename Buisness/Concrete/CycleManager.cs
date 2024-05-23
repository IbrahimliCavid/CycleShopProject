using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Buisness.Validations;
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
    public class CycleManager : ICycleService
    {
        public readonly ICycleDal _prdouctDal;
        public readonly IValidator<Cycle> _validator;

        public CycleManager(ICycleDal prdouctDal, IValidator<Cycle> validator)
        {
            _prdouctDal = prdouctDal;
            _validator = validator;
        }

        public IResult Add(CycleCreateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error)
        {

           
            var model = CycleMapper.ToModel(dto);

            var result = _validator.Validate(model);

            model.ImgUrl = PictureHelper.UploadImage(imgUrl, webRootPath);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    error = new ErrorDataResult<string>(item.PropertyName, item.ErrorMessage);
                    return error;
                }
            }

            error = null;
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

        public IResult Update(CycleUpdateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error)
        {
            var model = CycleMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            var existData = GetById(model.Id).Data;
            if (imgUrl == null)
            {
                model.ImgUrl = existData.ImgUrl;
            }
            else
            {
                model.ImgUrl = PictureHelper.UploadImage(imgUrl, webRootPath);
            }
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
