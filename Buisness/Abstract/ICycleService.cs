﻿using Core.Results.Abstract;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Buisness.Abstract
{
    public interface ICycleService
    {
        IResult Add(CycleCreateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error);
        IResult Update(CycleUpdateDto dto, IFormFile imgUrl, string webRootPath, out ErrorDataResult<string> error);
        IResult Delete(int id);
        IDataResult<Cycle> GetById(int id);
        IDataResult<List<CycleDto>> GetProductWithCycleCategoryId();
    }
}
