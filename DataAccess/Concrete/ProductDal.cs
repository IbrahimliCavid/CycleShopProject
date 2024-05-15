using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProductDal : BaseRepository<Product, ApplicationDbContext>, IProductDal
    {
        ApplicationDbContext context = new();
        public List<Product> GetCycleWithCycleCategories()
        {
            var data = context.Products
                .Where(x=>x.Deleted == 0)
                .Include(x => x.Category).ToList();
            return data;
        }
    }

}
