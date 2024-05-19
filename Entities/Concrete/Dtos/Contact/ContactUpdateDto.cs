using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public bool IsAnswer { get; set; }
    
    }
}
