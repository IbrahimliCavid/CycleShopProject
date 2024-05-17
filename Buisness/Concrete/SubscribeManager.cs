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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public IResult Add(Subscribe entity)
        {
            _subscribeDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _subscribeDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(Subscribe entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _subscribeDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<Subscribe>> GetAll()
        {
            return new SuccessDataResult<List<Subscribe>>(_subscribeDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Subscribe> GetById(int id)
        {
            return new SuccessDataResult<Subscribe>(_subscribeDal.GetById(id));
        }

    }
}
