using System.Threading.Tasks;

namespace Assecor.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}