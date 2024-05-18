using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class BestRacerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string EmailLink { get; set; }
        public static BestRacer ToModel(BestRacerDto dto)
        {
            BestRacer bestRacer = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Info = dto.Info,
                ImgUrl = dto.ImgUrl,
            };
            return bestRacer;
        }
    }
}
