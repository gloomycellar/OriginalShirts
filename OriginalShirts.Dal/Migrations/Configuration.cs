namespace OriginalShirts.Dal.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationContext context)
        {
            //XS, S, M, L, XL, XXL

            Size xs = new Size("XS");
            Size s = new Size("S");
            Size m = new Size("M");
            Size l = new Size("L");
            Size xl = new Size("XL");
            Size xxl = new Size("XXL");

            context.Set<Size>().Add(xs);
            context.Set<Size>().Add(s);
            context.Set<Size>().Add(m);
            context.Set<Size>().Add(l);
            context.Set<Size>().Add(xl);
            context.Set<Size>().Add(xxl);

            //White, Black, Red, Blue, Gray, Green, Pink
            Color White = new Color("White");
            Color Black = new Color("Black");
            Color Red = new Color("Red");
            Color Blue = new Color("Blue");
            Color Gray = new Color("Gray");
            Color Green = new Color("Green");
            Color Pink = new Color("Pink");

            context.Set<Color>().Add(White);
            context.Set<Color>().Add(Red);
            context.Set<Color>().Add(Blue);
            context.Set<Color>().Add(Gray);
            context.Set<Color>().Add(Green);
            context.Set<Color>().Add(Pink);

            Tag Nike = new Tag("Nike");
            Tag UnderArmour = new Tag("Under Armour");
            Tag Adidas = new Tag("Adidas");
            Tag Puma = new Tag("Puma");
            Tag Asics = new Tag("Asics");
            Tag Sportwear = new Tag("Sportwear");
            Tag Fendi = new Tag("Fendi");
            Tag Guess = new Tag("Guess");
            Tag Valentino = new Tag("Valentino");
            Tag Versache = new Tag("Versache");
            Tag Armani = new Tag("Armani");
            Tag Prada = new Tag("Prada");
            Tag DolceAndGabbana = new Tag("Dolce And Gabbana");
            Tag Chanel = new Tag("Chanel");
            Tag Gucci = new Tag("Gucci");
            Tag Mens = new Tag("Mens");
            Tag Womens = new Tag("Womens");
            Tag Kids = new Tag("Kids");
            Tag Fasion = new Tag("Fasion");
            Tag Households = new Tag("Households");
            Tag Interiors = new Tag("Interiors");
            Tag Clothing = new Tag("Clothing");
            Tag Bags = new Tag("Bags");
            Tag Shoes = new Tag("Shoes");

            context.Set<Tag>().Add(Nike);
            context.Set<Tag>().Add(UnderArmour);
            context.Set<Tag>().Add(Adidas);
            context.Set<Tag>().Add(Puma);
            context.Set<Tag>().Add(Asics);
            context.Set<Tag>().Add(Sportwear);
            context.Set<Tag>().Add(Fendi);
            context.Set<Tag>().Add(Guess);
            context.Set<Tag>().Add(Valentino);
            context.Set<Tag>().Add(Versache);
            context.Set<Tag>().Add(Armani);
            context.Set<Tag>().Add(Prada);
            context.Set<Tag>().Add(DolceAndGabbana);
            context.Set<Tag>().Add(Chanel);
            context.Set<Tag>().Add(Gucci);
            context.Set<Tag>().Add(Mens);
            context.Set<Tag>().Add(Womens);
            context.Set<Tag>().Add(Kids);
            context.Set<Tag>().Add(Fasion);
            context.Set<Tag>().Add(Households);
            context.Set<Tag>().Add(Interiors);
            context.Set<Tag>().Add(Clothing);
            context.Set<Tag>().Add(Bags);
            context.Set<Tag>().Add(Shoes);

            context.SaveChanges();

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition 1",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition 2",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                     context.Set<Tag>().Where(x => x.Name == "Shoes").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition 3",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition 4",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                   context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                   context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Sportwear").First(),
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                     context.Set<Tag>().Where(x => x.Name == "Mens").First(),
                    context.Set<Tag>().Where(x => x.Name == "Dolce And Gabbana").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Kids").First()
                }
            });

            context.Set<Shirt>().Add(new Shirt()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Mens").First(),
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            //-------------------------

            //List < Tag > children = new List<Tag>()
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
