﻿using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class BigSaleDto
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public static BigSale ToModel(BigSaleDto dto)
        {
            BigSale bigSale = new()
            {
                Id = dto.Id,
                ImgUrl = dto.ImgUrl,
            };
            return bigSale;
        }
    }
}
