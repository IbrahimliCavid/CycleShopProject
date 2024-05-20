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
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto);
        IResult Update(AboutUpdateDto entity);
        IDataResult<AboutUpdateDto> GetById(int id);
        IDataResult<List<AboutDto>> GetAll();
    }
}
