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
    public class BestRacerManager : IBestRacerService
    {
       public readonly IBestRacerDal _bestRacerDal;
        public readonly IValidator<BestRacer> _validator;

        public BestRacerManager(IBestRacerDal bestRacerDal, IValidator<BestRacer> validator)
        {
            _bestRacerDal = bestRacerDal;
            _validator = validator;
        }

        public IResult Add(BestRacerCreateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error)
        {

            var model = BestRacerMapper.ToModel(dto);

            var validator = _validator.Validate(model);
            model.ImgUrl = PictureHelper.UploadImage(imgUrl, webRootPath);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    error = new ErrorDataResult<string>(item.PropertyName, item.ErrorMessage);
                    return error;
                }
            }
            BeUniqueFacebook(dto);
            error = null;
            _bestRacerDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        private (bool,string) BeUniqueFacebook(BestRacerCreateDto dto)
        {
            var data = _bestRacerDal.GetAll(x => x.FacebookLink == dto.FacebookLink && x.Deleted == 0);
            return (!data.Any(), UIMessage.DEFAULT_ERROR_DUBLICATE_DATA);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
           
            data.Deleted = id;
            _bestRacerDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(BestRacerUpdateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error)
        {
            var model = BestRacerMapper.ToModel(dto);
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
            _bestRacerDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<BestRacerDto>> GetAll()
        {
            var models = _bestRacerDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<BestRacerDto>>(BestRacerMapper.ToDto(models));
        }

        public IDataResult<BestRacer> GetById(int id)
        {
            return new SuccessDataResult<BestRacer>(_bestRacerDal.GetById(id));
        }
    }
}
