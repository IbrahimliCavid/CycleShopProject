using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IResult Delete(int id);
        IResult Update(Contact contact);
        IDataResult<Contact> GetById(int id);
        IDataResult<List<Contact>> GetAll();
        
    }
}
