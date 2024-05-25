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
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto, IFormFile imgUrl, string webRootPath);
        IResult Update(ServiceUpdateDto dto, IFormFile imgUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<Service> GetById(int id);
        IDataResult<List<ServiceDto>> GetAll();
    }
}
