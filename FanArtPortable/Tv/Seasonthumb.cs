using Newtonsoft.Json;

namespace FanArtPortable.Tv
{
    public class Seasonthumb : BaseItem
    {
        [JsonProperty("season")]
        public string Season { get; set; }
    }
}