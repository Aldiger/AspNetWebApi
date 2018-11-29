using Assecor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Data
{
    public class ApplicationDbContextInitialization : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<Color> colors = new List<Color>();

            colors.Add(new Color() { Id = 1, Name = "Red" });
            colors.Add(new Color() { Id = 2, Name = "White" });
            colors.Add(new Color() { Id = 3, Name = "Green" });
            colors.Add(new Color() { Id = 4, Name = "Blue" });

            context.Colors.AddRange(colors);

            base.Seed(context);
        }
    }
}
