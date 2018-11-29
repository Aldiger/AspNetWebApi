using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Assecor.Data.Core.Interfaces;

namespace Assecor.Data.Core
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private const int BulkTimeout = 120;
        private const int BulkSize = 10000;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        #region Get

        public virtual async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetById(string id)
        {
            return await Context.Set<T>().FindAsync(id);
        }


        public virtual IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>();
        }

        public virtual IEnumerable<T> GetAllEnumerable()
        {
            return Context.Set<T>().ToList();
        }

        public virtual IList<T> Filter(Expression<Func<T, bool>> filterExpression)
        {
            return Context.Set<T>().Where(filterExpression).ToList();
        }


        public virtual IQueryable<T> GetPage(out int total, int page = 0, int rows = 0, string orderBy = null, string orderDir = null, string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();
            return GetPageCommon(out total, query, page, rows, orderBy, orderDir, includeProperties);
        }

        public virtual IQueryable<T> GetPageCommon(out int total, IQueryable<T> query, int page, int rows, string orderBy = null, string orderDir = null, string includeProperties = "")
        {
            total = query.Count();

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            //if (rows > 0)
            //{
            //    query = query.OrderBy($"{orderBy} {orderDir}").Skip(page * rows - rows).Take(rows);
            //}

            return query;
        }

        #endregion

        #region Add/Update

        public virtual async Task Add(T entity, bool autoCommit = true)
        {
            Context.Set<T>().Add(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }
        public virtual void AddSync(T entity, bool autoCommit = true)
        {
            Context.Set<T>().Add(entity);

            if (autoCommit)
            {
                Context.SaveChanges();
            }
        }

        public virtual async Task Add(IEnumerable<T> entities, bool autoCommit = true)
        {
            Context.Set<T>().AddRange(entities);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task Update(T entity, bool autoCommit = true)
        {
            Context.Entry(entity).State = EntityState.Modified;

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task AddOrUpdate(T entity, bool autoCommit = true)
        {
            Context.Set<T>().AddOrUpdate(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }


        #endregion

        #region Delete

        public virtual async Task Delete(T entity, bool autoCommit = true)
        {
            Context.Set<T>().Remove(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task Delete(IEnumerable<T> entities, bool autoCommit = true)
        {
            Context.Set<T>().RemoveRange(entities);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filterExpression, bool autoCommit = true)
        {
            await Delete(Filter(filterExpression), autoCommit);
        }

        public virtual async Task DeleteAll(bool autoCommit = true)
        {
            await Delete(g => true, autoCommit);
        }

        #endregion

        public async Task SaveChanges()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                var msg = !string.IsNullOrEmpty(e.Message) ? e.Message + "\r\n" : string.Empty;
                foreach (var eve in e.EntityValidationErrors.Where(g => g.Entry?.Entity != null))
                {
                    msg = "Entity error in " + eve.Entry.Entity.GetType().Name + "\r\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += "Field: " + ve.PropertyName + ".  Error: " + ve.ErrorMessage + "\r\n";
                    }
                }

                throw new Exception(msg);
            }
            catch (DbUpdateException e)
            {
                var msg = !string.IsNullOrEmpty(e.Message) ? e.Message + "\r\n" : string.Empty;
                foreach (var ent in e.Entries)
                {
                    msg = "Entity error in " + ent.Entity.GetType().Name + "\r\n";
                    msg += "Exception: " + e.Message + "\r\n";
                    if (e.InnerException?.InnerException != null)
                    {
                        msg += "Inner Exception: " + e.InnerException.InnerException.Message;
                    }
                }

                throw new Exception(msg);
            }
        }
    }
}