using System.Collections.Generic;
using System.Threading.Tasks;
using Assecor.Data.Entities;

namespace Assecor.Services.Interfaces
{
    public interface IColorService
    {
        List<ColorDto> GetColors();
    }
}