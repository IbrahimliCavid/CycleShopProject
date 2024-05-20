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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _cycleCategoryDal;
        private readonly IValidator<Category> _validator;

        public CategoryManager(ICategoryDal cycleCategoryDal, IValidator<Category> validator)
        {
            _cycleCategoryDal = cycleCategoryDal;
            _validator = validator;
        }

        public IResult Add(CategoryCreateDto dto)
        {
            var model = CategoryMapper.ToModel(dto);

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
            _cycleCategoryDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Update(CategoryUpdateDto dto)
        {
            var model = CategoryMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;


            _cycleCategoryDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = CategoryMapper.ToModel(data);
            model.Deleted = id;
            _cycleCategoryDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            var models = _cycleCategoryDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<CategoryDto>>(CategoryMapper.ToDto(models));
        }

        public IDataResult<CategoryUpdateDto> GetById(int id)
        {
            var model = _cycleCategoryDal.GetById(id);
            return new SuccessDataResult<CategoryUpdateDto>(CategoryMapper.ToUpdateDto(model));
        }

      
    }
}
