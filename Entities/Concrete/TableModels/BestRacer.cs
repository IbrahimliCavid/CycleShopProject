﻿using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class BestRacer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Info { get; set; }
        public string ImgUrl {  get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedinLink { get; set; }
 

    }
}
