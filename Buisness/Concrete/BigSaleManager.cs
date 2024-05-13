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
    public class BigSaleManager : IBigSaleService
    {
        BigSaleDal _bigSaleDal = new BigSaleDal();
        public IResult Add(BigSale entity)
        {
            _bigSaleDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _bigSaleDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
            
        }
        public IResult Update(BigSale entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _bigSaleDal.Update(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<BigSale>> GetAll()
        {
            return new  SuccessDataResult<List<BigSale>>(_bigSaleDal.GetAll(x=>x.Deleted == 0));
        }

        public IDataResult<BigSale> GetById(int id)
        {
            return new SuccessDataResult<BigSale>(_bigSaleDal.GetById(id));
        }

     
    }
}
