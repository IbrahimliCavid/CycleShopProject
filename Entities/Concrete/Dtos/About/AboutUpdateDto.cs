using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
