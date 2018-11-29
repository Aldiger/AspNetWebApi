using System.Data.Entity;

namespace Assecor.Data.Core.Interfaces
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}