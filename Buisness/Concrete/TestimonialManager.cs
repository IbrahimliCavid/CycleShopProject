using Buisness.Abstract;
using Buisness.BaseMessage;
using Buisness.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
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

        public IResult Add(TestimonialCreateDto dto)
        {
            var model = TestimonialMapping.ToModel(dto);
            _testimonialDal.Add(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_ADD_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model = TestimonialMapping.ToModel(data);
            model.Deleted = id;
            _testimonialDal.Update(model);
            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_DELETE_MESSAGE);
        }


        public IResult Update(TestimonialUpdateDto dto)
        {
            var model = TestimonialMapping.ToModel(dto);
            model.LastUpdateDate = DateTime.Now;
            _testimonialDal.Update(model);

            return new SuccessResult(UIMessage.DEFAULT_SUCCESS_UPDATE_MESSAGE);
        }
        public IDataResult<List<TestimonialDto>> GetAll()
        {
            var models = _testimonialDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<TestimonialDto>>(TestimonialMapping.ToDto(models));
        }

        public IDataResult<TestimonialDto> GetById(int id)
        {
            var model = _testimonialDal.GetById(id);
            return new SuccessDataResult<TestimonialDto>(TestimonialMapping.ToDto(model));
        }

    }
}
