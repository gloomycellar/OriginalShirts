namespace OriginalShirts.Dal.Models
{
    public class Size : EntityBase
    {
        public Size() { }

        public Size(string name)
        {
            Name = name;
        }

        //XS, S, M, L, XL, XXL
        public string Name { get; set; }
    }
}