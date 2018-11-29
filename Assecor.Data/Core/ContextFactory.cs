using System.Data.Entity;
using Assecor.Data;
using Assecor.Data.Core.Interfaces;


namespace Assecor.Data.Core
{
    public class ContextFactory : Disposable, IContextFactory
    {
        private DbContext _dbContext;
        private readonly string _cnString;

        public ContextFactory(string cnString)
        {
            _cnString = cnString;
        }

        public DbContext GetContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext(_cnString);
                _dbContext.Database.CommandTimeout = 600;   //10 minutes
            }

            return _dbContext;
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}