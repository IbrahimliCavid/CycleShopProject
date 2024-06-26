﻿using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICartItemService
    {
        IResult Add(CartItem cartItem);
        IDataResult<List<CartItemDto>> GetAll();
        IResult Update(CartItemDto dto);
        IResult Delete(int id);
        IDataResult<CartItem> GetById(int id);

    }
}
