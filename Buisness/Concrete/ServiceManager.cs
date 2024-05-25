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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _aboutDal;
        private readonly IValidator<Service> _validator;

        public ServiceManager(IServiceDal aboutDal, IValidator<Service> validator)
        {
            _aboutDal = aboutDal;
            _validator = validator;
        }

        public IResult Add(ServiceCreateDto dto, IFormFile imgUrl, string webRootPath)
        {
            var model = ServiceMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            model.ImgUrl = PictureHelper.UploadImage(imgUrl, webRootPath);
            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _aboutDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _aboutDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(ServiceUpdateDto dto, IFormFile imgUrl, string webRootPath)
        {
            var model = ServiceMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;

            var validator = _validator.Validate(model);
            var existData = GetById(model.Id).Data;
            if (imgUrl == null)
            {
                model.ImgUrl = existData.ImgUrl;
            }
            else
            {
                model.ImgUrl = PictureHelper.UploadImage(imgUrl, webRootPath);
            }
            string errorMessage = string.Empty;

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _aboutDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<ServiceDto>> GetAll()
        {
            var models = _aboutDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<ServiceDto>>(ServiceMapper.ToDto(models));
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_aboutDal.GetById(id));
        }

    }
}
