namespace OriginalShirts.Dal.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationContext context)
        {
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

            //List<Tag> children = new List<Tag>()
            //{
            //    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Nike").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Under Armour").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Adidas").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Puma").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Asics").First()
            //};

            //children = new List<Tag>()
            //{
            //    context.Set<Tag>().Where(x => x.Name == "Mens").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Fendi").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Guess").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Valentino").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Dior").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Versache").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Armani").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Prada").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Dolce And Gabbana").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Chanel").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Gucci").First()
            //};

            //children = new List<Tag>()
            //{
            //    context.Set<Tag>().Where(x => x.Name == "Womens").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Fendi").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Guess").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Valentino").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Dior").First(),
            //    context.Set<Tag>().Where(x => x.Name == "Versache").First()
            //};
        }
    }
}
