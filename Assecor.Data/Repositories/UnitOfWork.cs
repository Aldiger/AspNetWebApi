using Assecor.Data.Core.Interfaces;
using Assecor.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Assecor.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContextFactory _contextFactory;

        public UnitOfWork(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Commit()
        {
            await _contextFactory.GetContext().SaveChangesAsync();
        }
    }
}