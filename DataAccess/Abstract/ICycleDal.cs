using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ICycleDal: IBaseRepository<Product>
    {
        List<Product> GetCycleWithCycleCategories();
    }
}
