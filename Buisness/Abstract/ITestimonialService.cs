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
    public interface ITestimonialService
    {
        IResult Add(TestimonialCreateDto dto);
        IResult Update(TestimonialUpdateDto dto);
        IResult Delete(int id);
        IDataResult<TestimonialDto> GetById(int id);
        IDataResult<List<TestimonialDto>> GetAll();
    }
}
