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
    public class BestRacerManager : IBestRacerService
    {
       public readonly IBestRacerDal _bestRacerDal;

        public BestRacerManager(IBestRacerDal bestRacerDal)
        {
            _bestRacerDal = bestRacerDal;
        }

        public IResult Add(BestRacer entity)
        {
            _bestRacerDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _bestRacerDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(BestRacer entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _bestRacerDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<BestRacer>> GetAll()
        {
            return new SuccessDataResult<List<BestRacer>>(_bestRacerDal.GetAll(x=> x.Deleted == 0));
        }

        public IDataResult<BestRacer> GetById(int id)
        {
            return new SuccessDataResult<BestRacer>(_bestRacerDal.GetById(id));
        }

      
    }
}
