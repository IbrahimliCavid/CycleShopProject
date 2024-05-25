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
    public interface ISubscribeService
    {
        IResult Add(SubscribeCreateDto dto);
        IResult Update(SubscribeUpdateDto dto);
        IResult Delete(int id);
        IDataResult<Subscribe> GetById(int id);
        IDataResult<List<SubscribeDto>> GetAll();
    }
}
