using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public bool IsAnswer { get; set; }
        public static Contact ToModel(ContactCreateDto dto)
        {
            Contact contact = new()
            {
               
                Name = dto.Name,
                Surname = dto.Surname,
                Message = dto.Message,
                IsAnswer = dto.IsAnswer
            };
            return contact;
        }
    }
}
