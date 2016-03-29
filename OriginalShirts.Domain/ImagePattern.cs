using Newtonsoft.Json;

namespace OriginalShirts.Domain
{
    public class ImagePattern : EntityBase
    {
        public ImagePattern()
        {
        }

        public ImagePattern(string fileName, Color color, ImagePatternType patternType)
        {
            FileName = fileName;
            PatternType = patternType;
            Color = color;
        }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        public ImagePatternType PatternType { get; set; }

        public Color Color { get; set; }
    }
}
