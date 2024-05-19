using Core.Results.Abstract;
using Entities.Concrete.Dtos;
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
        IResult Add(ContactCreateDto dto);
        IResult Delete(int id);
        IResult Update(ContactUpdateDto dto);
        IDataResult<ContactDto> GetById(int id);
        IDataResult<List<ContactDto>> GetAll();
        
    }
}
