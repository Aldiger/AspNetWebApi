using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assecor.Data.Entities;
using Assecor.Data.Repositories.Interfaces;
using Assecor.Services.Interfaces;

namespace Assecor.Services.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public List<ColorDto> GetColors()
        {
           return  _colorRepository.GetAllEnumerable().ToList().Select(x=>new ColorDto
           {
               Id=x.Id,
               Name=x.Name
           }).ToList();
           
        }
    }
}