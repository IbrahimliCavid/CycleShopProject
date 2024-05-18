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
    public interface IActivityService
    {
        
        IResult Add(ActivityCreateDto activity);
        IResult Delete(int id);
        IResult Update(ActivityUpdateDto activity);
        IDataResult<ActivityDto> GetById(int id);
        IDataResult<List<ActivityDto>> GetAll();
    }
}


