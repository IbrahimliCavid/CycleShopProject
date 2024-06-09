using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapper
{
    public static class ShippingAdressMapper
    {

        public static ShippingAdressDto ToDto(ShippingAdress model)
        {
            ShippingAdressDto dto = new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PostalCode = model.PostalCode,
                Adress = model.Adress,
                Country = model.Country,
                State = model.State,
                City = model.City,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                UserId = model.UserId
            };
            return dto;
        }

        public static ShippingAdressUpdateDto ToUpdateDto(ShippingAdress model)
        {
            ShippingAdressUpdateDto dto = new ShippingAdressUpdateDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PostalCode = model.PostalCode,
                Adress = model.Adress,
                Country = model.Country,
                State = model.State,
                City = model.City,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                UserId = model.UserId
            };

            return dto;
        }

        public static List<ShippingAdressUpdateDto> ToUpdateDto(List<ShippingAdress> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static ShippingAdress ToModel(ShippingAdressCreateDto dto)
        {
            ShippingAdress model = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PostalCode = dto.PostalCode,
                Adress = dto.Adress,
                Country = dto.Country,
                State = dto.State,
                City = dto.City,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                UserId = dto.UserId
            };
            return model;
        }

        public static ShippingAdress ToModel(ShippingAdressDto dto)
        {
            ShippingAdress model = new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PostalCode = dto.PostalCode,
                Adress = dto.Adress,
                Country = dto.Country,
                State = dto.State,
                City = dto.City,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                UserId = dto.UserId

            };
            return model;
        }
        public static ShippingAdress ToModel(ShippingAdressUpdateDto dto)
        {
            ShippingAdress model = new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PostalCode = dto.PostalCode,
                Adress = dto.Adress,
                Country = dto.Country,
                State = dto.State,
                City = dto.City,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                UserId = dto.UserId
            };
            return model;
        }
    }
}
