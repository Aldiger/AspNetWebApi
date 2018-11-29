using Assecor.Data.Core;
using Assecor.Data.Core.Interfaces;
using Assecor.Data.Entities;
using Assecor.Data.Repositories.Interfaces;

namespace Assecor.Data.Repositories
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(IContextFactory factory) : base(factory.GetContext())
        {
        }
    }
}
