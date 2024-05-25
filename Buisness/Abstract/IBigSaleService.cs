using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IBigSaleService
    {
        IResult Add(BigSaleCreateDto dto, IFormFile imgUrl, string webRootPath);
        IResult Update(BigSaleUpdateDto dto, IFormFile imgUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<BigSale> GetById(int id);
        IDataResult<List<BigSaleDto>> GetAll();
    }
}
