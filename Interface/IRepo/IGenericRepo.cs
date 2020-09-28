using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IRepo
{
    public interface IGenericRepo<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> Get(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
        IEnumerable<T> ExecWithStoreProcedure(string querys);
    }
}
