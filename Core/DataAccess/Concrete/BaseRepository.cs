using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<TEntity> GetAll()
        {

            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetByID(int id)
        {
            using (TContext context = new TContext()) 
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

      
    }
}
