using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assecor.Data.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetById(Guid id);
        Task<T> GetById(string id);
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetAllEnumerable();
        IList<T> Filter(Expression<Func<T, bool>> filterExpression);
        IQueryable<T> GetPage(out int total, int page = 0, int rows = 0, string orderBy = null, string orderDir = null, string includeProperties = "");
        IQueryable<T> GetPageCommon(out int total, IQueryable<T> query, int page, int rows, string orderBy = null, string orderDirr = null, string includeProperties = "");

        Task Add(T entity, bool autoCommit = true);
        void AddSync(T entity, bool autoCommit = true);
        Task Add(IEnumerable<T> entities, bool autoCommit = true);
        Task Update(T entity, bool autoCommit = true);
        Task AddOrUpdate(T entity, bool autoCommit = true);

        Task Delete(T entity, bool autoCommit = true);
        Task Delete(IEnumerable<T> entities, bool autoCommit = true);
        Task Delete(Expression<Func<T, bool>> filterExpression, bool autoCommit = true);
        Task DeleteAll(bool autoCommit = true);

        Task SaveChanges();
    }
}
