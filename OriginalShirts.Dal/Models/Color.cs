namespace OriginalShirts.Dal.Models
{
    public class Color : EntityBase
    {
        public Color() { }

        public Color(string name)
        {
            Name = name;
        }

        //White,
        //Black,
        //Red,
        //Blue,
        //Gray,
        //Green,
        //Pink
        public string Name { get; set; }
    }
}