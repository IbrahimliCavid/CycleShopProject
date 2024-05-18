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
    public interface IBestRacerService
    {
        IResult Add(BestRacerCreateDto entity);
        IResult Delete(int id);
        IResult Update(BestRacerUpdateDto entity);

        IDataResult<BestRacerDto> GetById(int id);
        IDataResult<List<BestRacerDto>> GetAll();
    }
}
