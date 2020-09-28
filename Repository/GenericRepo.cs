using Interface.IRepo;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T: class
    {
        private BS23DBContext context;
        string errorMessage = string.Empty;

        public virtual IQueryable<T> Table
        {
            get
            {
                return context.Set<T>();
            }
        }
        public GenericRepo(BS23DBContext context)
        {
            this.context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> Get(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<T>().Add(entity);
            // context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<T>().Remove(entity);
        }
        public void Delete(object id)
        {
            var entity = context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
        }
        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters);
        }
        public IEnumerable<T> ExecWithStoreProcedure(string querys)
        {
            return context.Database.SqlQuery<T>(querys);
        }
    }
}