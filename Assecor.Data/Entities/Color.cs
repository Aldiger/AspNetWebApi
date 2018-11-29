using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Data.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        public ICollection<Person> Persons { get; set; }
    }
}
