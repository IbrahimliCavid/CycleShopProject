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
    public interface ICategoryService
    {
        IResult Add(CategoryCreateDto cycleCategory);
        IResult Delete(int id);
        IResult Update(CategoryUpdateDto cycleCategory);

        IDataResult<CategoryDto> GetById(int id);
        IDataResult<List<CategoryDto>> GetAll();
    }
}
