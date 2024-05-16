using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ServiceDal : BaseRepository<Service, ApplicationDbContext>, IServiceDal
    { }

}
