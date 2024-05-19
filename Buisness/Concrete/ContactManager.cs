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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(ContactCreateDto dto)
        {
            var model = ContactMapper.ToModel(dto);
           _contactDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = ContactMapper.ToModel(data);
            model.Deleted = id;
            _contactDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }

        public IResult Update(ContactUpdateDto dto)
        {
            var model = ContactMapper.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
           _contactDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<ContactDto>> GetAll()
        {
            var models = _contactDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<ContactDto>>(ContactMapper.ToDto(models));
        }

        public IDataResult<ContactDto> GetById(int id)
        {
            var model = _contactDal.GetById(id);
            return new SuccessDataResult<ContactDto>(ContactMapper.ToDto(model));
        }

    
    }
}
