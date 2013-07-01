using Newtonsoft.Json;

namespace FanArtPortable.Movies
{
    public class Moviedisc : BaseItem
    {
        [JsonProperty("disc")]
        public string Disc { get; set; }

        [JsonProperty("disc_type")]
        public string DiscType { get; set; }
    }
}