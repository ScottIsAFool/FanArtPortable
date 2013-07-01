using Newtonsoft.Json;

namespace FanArtPortable.Music
{
    public class CdArt : ArtistBase
    {
        [JsonProperty("disc")]
        public string Disc { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }
}