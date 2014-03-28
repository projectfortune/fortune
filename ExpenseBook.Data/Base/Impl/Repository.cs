using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseBook.Data.Base.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["ExpenseBookEntities"].ToString();

        protected ObjectContext Context;

        protected ObjectQuery<TEntity> EntityObjectQuery;

        protected ObjectSet<TEntity> ObjectSet;

        public Repository()
        {

            Context = GetObjectContext(_connString);
            ObjectSet = Context.CreateObjectSet<TEntity>();
        }


        public IQueryable<TEntity> GetQuery()
        {
            return ObjectSet.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return ObjectSet.Where(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return ObjectSet.SingleOrDefault(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return ObjectSet.FirstOrDefault(predicate);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ObjectSet.DeleteObject(entity);
        }


        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ObjectSet.AddObject(entity);
        }


        public void Attach(TEntity entity)
        {
            ObjectSet.Attach(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void SaveChanges(SaveOptions options)
        {
            Context.SaveChanges(options);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private ObjectContext GetObjectContext(string connectionStringName)
        {
            return new ObjectContext(connectionStringName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}
