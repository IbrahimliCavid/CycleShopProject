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

        public static ActivityUpdateDto ToUpdateDto(Activity model)
        {
            ActivityUpdateDto dto = new()
            {
                Id = model.Id,
                ActivityInfo = model.ActivityInfo,
                IsHomePage = model.IsHomePage,
            };
            return dto;
        }

        public static List<ActivityUpdateDto> ToUpdateDto(List<Activity> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }
        public static Activity ToModel(ActivityCreateDto dto)
        {
            Activity model = new()
            {
                ActivityInfo = dto.ActivityInfo,
                IsHomePage = dto.IsHomePage,
            };
            return model;
        }

        public static Activity ToModel(ActivityDto dto)
        {
            Activity model = new()
            {
                Id = dto.Id,
                ActivityInfo = dto.ActivityInfo,
                IsHomePage = dto.IsHomePage,
            };
            return model;
        }


        public static Activity ToModel(ActivityUpdateDto dto)
        {
            Activity model = new()
            {
                Id = dto.Id,
                ActivityInfo = dto.ActivityInfo,
                IsHomePage = dto.IsHomePage,

            };
            return model;
        }
    }
}
