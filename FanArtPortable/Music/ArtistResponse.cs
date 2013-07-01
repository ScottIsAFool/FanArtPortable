using Newtonsoft.Json;

namespace FanArtPortable.Music
{
    internal class ArtistResponse
    {
        [JsonProperty("item")]
        public Artist Artist { get; set; }
    }
}