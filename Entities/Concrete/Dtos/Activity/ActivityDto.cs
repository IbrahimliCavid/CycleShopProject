using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string ActivityInfo { get; set; }
        public bool IsHomePage { get; set; }
      
    }
}
