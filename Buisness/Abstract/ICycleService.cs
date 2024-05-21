using Core.Results.Abstract;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;

namespace Buisness.Abstract
{
    public interface ICycleService
    {
       IResult Add(CycleCreateDto dto, out ErrorDataResult<string> error);
        IResult Update(CycleUpdateDto dto, out ErrorDataResult<string> error);
        IResult Delete(int id);
        IDataResult<CycleUpdateDto> GetById(int id);
        IDataResult<List<CycleDto>> GetProductWithCycleCategoryId();
    }
}
