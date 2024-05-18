using Entities.Concrete.TableModels;


namespace Entities.Concrete.Dtos
{
    public  class ActivityCreateDto
    {
        public string ActivityInfo { get; set; }
        public bool IsHomePage { get; set; }
        public static Activity ToModel(ActivityCreateDto dto)
        {
            Activity model = new()
            {
                ActivityInfo = dto.ActivityInfo,
                IsHomePage = dto.IsHomePage,
            };
            return model;
        }
    }

}
