﻿using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public int Id {  get; set; }
        public static Category ToModel(CategoryDto dto)
        {
            Category category = new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return category;
        }
    }
}
