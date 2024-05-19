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
    public interface IBigSaleService
    {
        IResult Add(BigSaleCreateDto dto);
        IResult Update(BigSaleUpdateDto dto);
        IResult Delete(int id);
        IDataResult<BigSaleDto> GetById(int id);
        IDataResult<List<BigSaleDto>> GetAll();
    }
}
