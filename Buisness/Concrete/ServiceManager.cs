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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _aboutDal;

        public ServiceManager(IServiceDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(Service entity)
        {
            _aboutDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _aboutDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(Service entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _aboutDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_aboutDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_aboutDal.GetById(id));
        }

    }
}
