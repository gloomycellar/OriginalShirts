namespace OriginalShirts.Dal.Migrations
{
    using Domain;
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
            Color White = new Color("White", "White");
            Color Black = new Color("Black", "Black");
            Color Blue = new Color("Blue", "#00b5e3");
            Color Gray = new Color("Gray", "#aaaaaa");
            Color Yellow = new Color("Yellow", "#e4c300");
            Color Green = new Color("Green", "#66c926");
            Color Pink = new Color("Pink", "#d44d78");

            context.Set<Color>().Add(White);
            context.Set<Color>().Add(Black);
            context.Set<Color>().Add(Gray);
            context.Set<Color>().Add(Blue);
            context.Set<Color>().Add(Yellow);
            context.Set<Color>().Add(Green);
            context.Set<Color>().Add(Pink);

            context.Set<TagGroup>().Add(new TagGroup("Sportwear"));
            context.Set<TagGroup>().Add(new TagGroup("Mens"));
            context.Set<TagGroup>().Add(new TagGroup("Womens"));

            context.SaveChanges();

            HashSet<TagGroup> Sportwear = new HashSet<TagGroup>()
            {
                context.Set<TagGroup>().Where(x => x.Name == "Sportwear").First()
            };

            HashSet<TagGroup> MensWomens = new HashSet<TagGroup>()
            {
                context.Set<TagGroup>().Where(x => x.Name == "Mens").First(),
                context.Set<TagGroup>().Where(x => x.Name == "Womens").First()
            };

            HashSet<TagGroup> Mens = new HashSet<TagGroup>()
            {
                context.Set<TagGroup>().Where(x => x.Name == "Mens").First()
            };

            Tag Nike = new Tag("Nike", Sportwear);
            Tag UnderArmour = new Tag("Under Armour", Sportwear);
            Tag Adidas = new Tag("Adidas", Sportwear);
            Tag Puma = new Tag("Puma", Sportwear);
            Tag Asics = new Tag("Asics", Sportwear);

            Tag Fendi = new Tag("Fendi", MensWomens);
            Tag Guess = new Tag("Guess", MensWomens);
            Tag Valentino = new Tag("Valentino", MensWomens);
            Tag Versache = new Tag("Versache", MensWomens);
            Tag Armani = new Tag("Armani", Mens);
            Tag Prada = new Tag("Prada", Mens);
            Tag DolceAndGabbana = new Tag("Dolce And Gabbana", Mens);
            Tag Chanel = new Tag("Chanel", Mens);
            Tag Gucci = new Tag("Gucci", Mens);

            Tag Kids = new Tag("Kids", null);
            Tag Fasion = new Tag("Fasion", null);
            Tag Households = new Tag("Households", null);
            Tag Interiors = new Tag("Interiors", null);
            Tag Clothing = new Tag("Clothing", null);
            Tag Bags = new Tag("Bags", null);
            Tag Shoes = new Tag("Shoes", null);

            context.Set<Tag>().Add(Nike);
            context.Set<Tag>().Add(UnderArmour);
            context.Set<Tag>().Add(Adidas);
            context.Set<Tag>().Add(Puma);
            context.Set<Tag>().Add(Asics);
            context.Set<Tag>().Add(Fendi);
            context.Set<Tag>().Add(Guess);
            context.Set<Tag>().Add(Valentino);
            context.Set<Tag>().Add(Versache);
            context.Set<Tag>().Add(Armani);
            context.Set<Tag>().Add(Prada);
            context.Set<Tag>().Add(DolceAndGabbana);
            context.Set<Tag>().Add(Chanel);
            context.Set<Tag>().Add(Gucci);
            context.Set<Tag>().Add(Kids);
            context.Set<Tag>().Add(Fasion);
            context.Set<Tag>().Add(Households);
            context.Set<Tag>().Add(Interiors);
            context.Set<Tag>().Add(Clothing);
            context.Set<Tag>().Add(Bags);
            context.Set<Tag>().Add(Shoes);

            context.SaveChanges();

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition 1",
                Price = 56,
                Image = "/images/shop/product12.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition 2",
                Price = 56,
                Image = "/images/shop/product11.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                     context.Set<Tag>().Where(x => x.Name == "Shoes").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition 3",
                Price = 56,
                Image = "/images/shop/product10.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition 4",
                Price = 56,
                Image = "/images/shop/product9.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/product8.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/product7.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product6.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product5.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product5.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });
            //--
            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Nike").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Dolce And Gabbana").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Kids").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/home/product4.jpg",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });             
        }
    }
}
