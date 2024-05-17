using Buisness.Abstract;
using Buisness.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(Testimonial entity)
        {
            _testimonialDal.Add(entity);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _testimonialDal.Update(data);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(Testimonial entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _testimonialDal.Update(entity);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.GetById(id));
        }

    }
}
