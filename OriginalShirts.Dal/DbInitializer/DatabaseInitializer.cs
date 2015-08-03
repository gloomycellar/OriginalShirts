using OriginalShirts.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Dal.DbInitializer
{
    class DatabaseInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            base.Seed(context);

            //XS, S, M, L, XL, XXL
            context.Set<Size>().Add(new Size("XS"));
            context.Set<Size>().Add(new Size("S"));
            context.Set<Size>().Add(new Size("M"));
            context.Set<Size>().Add(new Size("L"));
            context.Set<Size>().Add(new Size("XL"));
            context.Set<Size>().Add(new Size("XXL"));

            //White, Black, Red, Blue, Gray, Green, Pink
            context.Set<Color>().Add(new Color("White"));
            context.Set<Color>().Add(new Color("Black"));
            context.Set<Color>().Add(new Color("Red"));
            context.Set<Color>().Add(new Color("Blue"));
            context.Set<Color>().Add(new Color("Gray"));
            context.Set<Color>().Add(new Color("Green"));
            context.Set<Color>().Add(new Color("Pink"));

            context.Set<Tag>().Add(new Tag("Nike"));
            context.Set<Tag>().Add(new Tag("Under Armour"));
            context.Set<Tag>().Add(new Tag("Adidas"));
            context.Set<Tag>().Add(new Tag("Puma"));
            context.Set<Tag>().Add(new Tag("Asics"));
            context.Set<Tag>().Add(new Tag("Sportwear"));
            context.Set<Tag>().Add(new Tag("Fendi"));
            context.Set<Tag>().Add(new Tag("Guess"));
            context.Set<Tag>().Add(new Tag("Valentino"));
            context.Set<Tag>().Add(new Tag("Dior"));
            context.Set<Tag>().Add(new Tag("Versache"));
            context.Set<Tag>().Add(new Tag("Armani"));
            context.Set<Tag>().Add(new Tag("Prada"));
            context.Set<Tag>().Add(new Tag("Dolce And Gabbana"));
            context.Set<Tag>().Add(new Tag("Chanel"));
            context.Set<Tag>().Add(new Tag("Gucci"));
            context.Set<Tag>().Add(new Tag("Mens"));
            context.Set<Tag>().Add(new Tag("Womens"));


            List<Tag> children = new List<Tag>()
            {
                new Tag("Nike"),
                new Tag("Under Armour"),
                new Tag("Adidas"),
                new Tag("Puma"),
                new Tag("Asics"),
            };
            context.Set<Tag>().Add(new Tag("Sportwear", children));

            children = new List<Tag>()
            {
                new Tag("Fendi"),
                new Tag("Guess"),
                new Tag("Valentino"),
                new Tag("Dior"),
                new Tag("Versache"),
                new Tag("Armani"),
                new Tag("Prada"),
                new Tag("Dolce And Gabbana"),
                new Tag("Chanel"),
                new Tag("Gucci"),
            };
            context.Set<Tag>().Add(new Tag("Mens", children));

            children = new List<Tag>()
            {
                new Tag("Fendi"),
                new Tag("Guess"),
                new Tag("Valentino"),
                new Tag("Dior"),
                new Tag("Versache")               
            };
            context.Set<Tag>().Add(new Tag("Womens", children));
        }
    }
}
