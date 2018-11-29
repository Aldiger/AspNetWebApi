using Assecor.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Data.Entities
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        public ICollection<PersonDto> Persons { get; set; }
    }
}
