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
    public interface ICycleService
    {
        IResult Add(CycleCreateDto dto);
        IResult Update(CycleUpdateDto dto);
        IResult Delete(int id);
        IDataResult<Cycle> GetById(int id);
        IDataResult<List<CycleDto>> GetProductWithCycleCategoryId();
    }
}
