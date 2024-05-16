using Buisness.Abstract;
using Buisness.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
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
        CategoryDal _cycleCategoryDal = new();
        public IResult Add(CycleCategory cycleCategory)
        {
          _cycleCategoryDal.Add(cycleCategory);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Update(CycleCategory cycleCategory)
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

        public IDataResult<List<CycleCategory>> GetAll()
        {
            return new SuccessDataResult<List<CycleCategory>>(_cycleCategoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<CycleCategory> GetById(int id)
        {
            return new SuccessDataResult<CycleCategory>(_cycleCategoryDal.GetById(id));
        }

      
    }
}
