using Buisness.Abstract;
using Buisness.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
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

        public IResult Add(Category cycleCategory)
        {
          _cycleCategoryDal.Add(cycleCategory);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Update(Category cycleCategory)
        {
            cycleCategory.LastUpdateDate = DateTime.Now;
            _cycleCategoryDal.Update(cycleCategory);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _cycleCategoryDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_cycleCategoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_cycleCategoryDal.GetById(id));
        }

      
    }
}
