using Core.DataAccess.Concret;
using DataAccess.Abstract;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CycleDal : BaseRepository<Cycle, ApplicationDbContext>, ICycleDal
    {
        private readonly ApplicationDbContext _context;

        public CycleDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CycleDto> GetCycleWithCycleCategories()
        {
            var result = from cycle in _context.Cycles
                         where cycle.Deleted == 0
                         join cycleC in _context.Categories
                         on cycle.CategoryId equals cycleC.Id
                         where cycleC.Deleted == 0
                         select new CycleDto
                         {
                             Id = cycle.Id,
                             Name = cycle.Name,
                             CategoryId = cycle.CategoryId,
                             ImgUrl = cycle.ImgUrl,
                             StarRating = cycle.StarRating,
                             Count = cycle.Count,
                             Price = cycle.Price,
                             PrecentOfDiscount = cycle.PrecentOfDiscount,
                             IsHomePage = cycle.IsHomePage,
                             CategoryName = cycleC.Name
                         };

            return result.ToList();



        }
    }

}
