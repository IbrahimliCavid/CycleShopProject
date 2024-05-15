using Core.Results.Abstract;
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
        IResult Add(Testimonial entity);
        IResult Update(Testimonial entity);
        IResult Delete(int id);
        IDataResult<Testimonial> GetById(int id);
        IDataResult<List<Testimonial>> GetAll();
    }
}
