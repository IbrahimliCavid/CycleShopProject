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
    public class BestRacerManager : IBestRacerService
    {
        BestRacerDal _bestRacerDal = new BestRacerDal();
        public IResult Add(BestRacer entity)
        {
            _bestRacerDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(BestRacer entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(BestRacer entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _bestRacerDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }

        public IDataResult<List<BestRacer>> GetAll()
        {
            return new SuccessDataResult<List<BestRacer>>(_bestRacerDal.GetAll());
        }

        public IDataResult<BestRacer> GetById(int id)
        {
            return new SuccessDataResult<BestRacer>(_bestRacerDal.GetByID(id));
        }

      
    }
}
