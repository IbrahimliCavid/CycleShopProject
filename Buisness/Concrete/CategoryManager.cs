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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _cycleCategoryDal;

        public CategoryManager(ICategoryDal cycleCategoryDal)
        {
            _cycleCategoryDal = cycleCategoryDal;
        }

        public IResult Add(CategoryCreateDto dto)
        {
            var model = CategoryMapper.ToModel(dto);
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

        public IDataResult<CategoryDto> GetById(int id)
        {
            var model = _cycleCategoryDal.GetById(id);
            return new SuccessDataResult<CategoryDto>(CategoryMapper.ToDto(model));
        }

      
    }
}
