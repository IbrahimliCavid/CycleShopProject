﻿using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICycleCategoryService
    {
        IResult Add(CycleCategory cycleCategory);
        IResult Delete(int id);
        IResult Update(CycleCategory cycleCategory);

        IDataResult<CycleCategory> GetById(int id);
        IDataResult<List<CycleCategory>> GetAll();
    }
}