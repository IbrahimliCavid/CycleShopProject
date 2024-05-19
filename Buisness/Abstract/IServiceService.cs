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
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto);
        IResult Update(ServiceUpdateDto dto);
        IResult Delete(int id);
        IDataResult<ServiceDto> GetById(int id);
        IDataResult<List<ServiceDto>> GetAll();
    }
}
