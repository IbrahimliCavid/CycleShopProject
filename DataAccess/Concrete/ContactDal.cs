﻿using Core.DataAccess.Concret;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ContactDal : BaseRepository<Contact, ApplicationDbContext> { }

}