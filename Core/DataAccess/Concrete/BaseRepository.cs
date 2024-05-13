using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concret
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var addEntity = contex.Entry(entity);
                addEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext contex = new TContext()) 
            {
                var updateEntity = contex.Entry(entity);
                updateEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var deleteEntity = contex.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
           using (TContext contex = new TContext())
            {
                if(filter == null)
                    return contex.Set<TEntity>().ToList();
                else 
                    return contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById (int id)
        {
            using (TContext context = new TContext()) 
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

      
    }
}
