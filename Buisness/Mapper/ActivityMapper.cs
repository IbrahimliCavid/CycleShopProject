using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapper
{
    public class ActivityMapper
    {
        public static ActivityDto ToDto(Activity model)
        {
            ActivityDto dto = new()
            {
                Id = model.Id,
                ActivityInfo = model.ActivityInfo,
                IsHomePage = model.IsHomePage,
            };
            return dto;
        }

        public static List<ActivityDto> ToDto(List<Activity> models) 
        {
            return models.Select(x => ToDto(x)).ToList();
        }
    }
}
