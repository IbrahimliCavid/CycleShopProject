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
    public class CycleManager : ICycleService
    {
        public readonly CycleDal _prdouctDal = new CycleDal();
        public IResult Add(Product entity)
        {
            _prdouctDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _prdouctDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(Product entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _prdouctDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

    
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_prdouctDal.GetById(id));
        }

        public IDataResult<List<Product>> GetProductWithCycleCategoryId()
        {
            return new SuccessDataResult<List<Product>>(_prdouctDal.GetCycleWithCycleCategories());
        }
    }
}
