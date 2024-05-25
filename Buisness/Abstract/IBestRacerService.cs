using Core.Results.Abstract;
using Core.Results.Concrete;
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
    public interface IBestRacerService
    {
        IResult Add(BestRacerCreateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error);
        IResult Delete(int id);
        IResult Update(BestRacerUpdateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error);

        IDataResult<BestRacer> GetById(int id);
        IDataResult<List<BestRacerDto>> GetAll();
    }
}
