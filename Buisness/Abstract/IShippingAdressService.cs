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
    public interface IShippingAdressService
    {
        IResult Add(ShippingAdressCreateDto dto);
        IResult Update(ShippingAdressUpdateDto dto);
        IResult Delete(int id);
        IDataResult<ShippingAdress> GetById(int id);
        IDataResult<List<ShippingAdressDto>> GetShippingAdressWithUser();
    }
}
