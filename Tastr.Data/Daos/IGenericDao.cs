using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tastr.Data
{
    public interface IGenericRepository<T> where T : class
    {
        T Find(int id);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}