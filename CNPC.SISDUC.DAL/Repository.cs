using CNPC.SISDUC.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        CNPC_DuctosEntities Context = null;
        public Repository()
        {
            Context = new CNPC_DuctosEntities();
        }
        public DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }

        }
        public TEntity Create(TEntity toCreate)
        {
            TEntity Result = null;
            try
            {
                EntitySet.Add(toCreate);
                Context.SaveChanges();
                Result = toCreate;
            }
            catch
            {
            }
            return Result;
        }

        public bool Delete(TEntity toDelete)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                Result = Context.SaveChanges() > 0;
            }
            catch
            {
            }
            return Result;
        }

        public bool Update(TEntity toUpdate)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toUpdate);
                Context.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                Result = Context.SaveChanges() > 0;
            }
            catch
            {
            }
            return Result;
        }

        public TEntity Retrieve(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            TEntity Result = null;
            try
            {
                Result = EntitySet.FirstOrDefault(criteria);
            }
            catch 
            {
                
            }
            return Result;
        }

        public List<TEntity> Filter(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).ToList();
            }
            catch
            {

            }
            return Result;
        }

        public void Dispose()
        {
            if (Context!=null)
            {
                Context.Dispose();
            }
        }
    }
}
