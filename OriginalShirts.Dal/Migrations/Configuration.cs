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

            Color white = context.Set<Color>().Where(x => x.Name == "White").First();
            Color black = context.Set<Color>().Where(x => x.Name == "Black").First();
            Color gray = context.Set<Color>().Where(x => x.Name == "Gray").First();
            Color blue = context.Set<Color>().Where(x => x.Name == "Blue").First();
            Color yellow = context.Set<Color>().Where(x => x.Name == "Yellow").First();
            Color green = context.Set<Color>().Where(x => x.Name == "Green").First();
            Color pink = context.Set<Color>().Where(x => x.Name == "Pink").First();

            context.Set<ImagePattern>().Add(new ImagePattern("21988_478.png", blue, ImagePatternType.Men));
            context.Set<ImagePattern>().Add(new ImagePattern("219878_478.png", white, ImagePatternType.Men));
            context.Set<ImagePattern>().Add(new ImagePattern("219884_478.png", gray, ImagePatternType.Men));
            context.Set<ImagePattern>().Add(new ImagePattern("219885_478.png", yellow, ImagePatternType.Men));
            context.Set<ImagePattern>().Add(new ImagePattern("219887_478.png", black, ImagePatternType.Men));
            context.Set<ImagePattern>().Add(new ImagePattern("2198855_478.png", green, ImagePatternType.Men));

            context.Set<ImagePattern>().Add(new ImagePattern("23005_478 (1).png", pink, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("23005_478.png", white, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("23005_4978.png", blue, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("230052_478.png", green, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("230054_478.png", yellow, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("230055_478.png", black, ImagePatternType.Women));
            context.Set<ImagePattern>().Add(new ImagePattern("230056_478.png", gray, ImagePatternType.Women));

            context.Set<ImagePattern>().Add(new ImagePattern("1.png", white, ImagePatternType.Child));
            context.Set<ImagePattern>().Add(new ImagePattern("2.png", black, ImagePatternType.Child));
            context.Set<ImagePattern>().Add(new ImagePattern("3.png", gray, ImagePatternType.Child));
            context.Set<ImagePattern>().Add(new ImagePattern("4.png", blue, ImagePatternType.Child));
            context.Set<ImagePattern>().Add(new ImagePattern("5.png", yellow, ImagePatternType.Child));

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
                Image = "/images/shop/Img_0001.jpg",
                Logo = "Img_0001.png",
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
                Image = "/images/shop/Img_0007.jpg",
                Logo = "Img_0007.png",
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
                Image = "/images/shop/Img_0008.jpg",
                Logo = "Img_0008.png",
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
                Image = "/images/shop/Img_0010.jpg",
                Logo = "Img_0010.png",
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
                Image = "/images/shop/Img_0011.jpg",
                Logo = "Img_0011.png",
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
                Image = "/images/shop/Img_0012.jpg",
                Logo = "Img_0012.png",
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
                Image = "/images/shop/Img_0013.jpg",
                Logo = "Img_0013.png",
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
                Image = "/images/shop/Img_0014.jpg",
                Logo = "Img_0014.png",
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
                Image = "/images/shop/Img_0015.jpg",
                Logo = "Img_0015.png",
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
                Image = "/images/shop/Img_0016.jpg",
                Logo = "Img_0016.png",
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
                Image = "/images/shop/Img_0017.jpg",
                Logo = "Img_0017.png",
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
                Image = "/images/shop/Img_0018.jpg",
                Logo = "Img_0018.png",
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
                Image = "/images/shop/Img_0019.jpg",
                Logo = "Img_0019.png",
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
                Image = "/images/shop/Img_0023.jpg",
                Logo = "Img_0023.png",
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
                Image = "/images/shop/Img_0030.jpg",
                Logo = "Img_0030.png",
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
                Image = "/images/shop/Img_0033.jpg",
                Logo = "Img_0033.png",
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
                Image = "/images/shop/Img_0034.jpg",
                Logo = "Img_0034.png",
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
                Image = "/images/shop/Img_0035.jpg",
                Logo = "Img_0035.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0036.jpg",
                Logo = "Img_0036.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });


            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0037.jpg",
                Logo = "Img_0037.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0039.jpg",
                Logo = "Img_0039.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0040.jpg",
                Logo = "Img_0040.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0041.jpg",
                Logo = "Img_0041.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0042.jpg",
                Logo = "Img_0042.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0043.jpg",
                Logo = "Img_0043.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0045.jpg",
                Logo = "Img_0045.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0046.jpg",
                Logo = "Img_0046.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0048.jpg",
                Logo = "Img_0048.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0049.jpg",
                Logo = "Img_0049.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0051.jpg",
                Logo = "Img_0051.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0059.jpg",
                Logo = "Img_0059.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0064.jpg",
                Logo = "Img_0064.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0065.jpg",
                Logo = "Img_0065.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0066.jpg",
                Logo = "Img_0066.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0067.jpg",
                Logo = "Img_0067.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0068.jpg",
                Logo = "Img_0068.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0069.jpg",
                Logo = "Img_0069.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0076.jpg",
                Logo = "Img_0076.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0078.jpg",
                Logo = "Img_0078.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0079.jpg",
                Logo = "Img_0079.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_0080.jpg",
                Logo = "Img_0080.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });
            
            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_1087.jpg",
                Logo = "Img_1087.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_1088.jpg",
                Logo = "Img_1088.png",
                Color = context.Set<Color>().Where(x => x.Name == "White").First(),
                Size = context.Set<Size>().Where(x => x.Name == "XS").First(),
                Tags = new List<Tag>()
                {
                    context.Set<Tag>().Where(x => x.Name == "Fendi").First()
                }
            });

            context.Set<Product>().Add(new Product()
            {
                Name = "Easy Polo Black Edition",
                Price = 56,
                Image = "/images/shop/Img_1089.jpg",
                Logo = "Img_1089.png",
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
