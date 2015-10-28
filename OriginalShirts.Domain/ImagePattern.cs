using Newtonsoft.Json;

namespace OriginalShirts.Domain
{
    public class ImagePattern : EntityBase
    {
        public ImagePattern()
        {
        }

        public ImagePattern(string fileName, ImagePatternType patternType)
        {
            FileName = fileName;
            PatternType = patternType;
        }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        public ImagePatternType PatternType { get; set; }
    }
}
