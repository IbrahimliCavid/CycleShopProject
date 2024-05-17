using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class SubscribeDal : BaseRepository<Subscribe, ApplicationDbContext>, ISubscribeDal
    { }

}
