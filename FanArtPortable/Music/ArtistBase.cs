using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Music
{
    [ImplementPropertyChanged]
    public abstract class ArtistBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("likes")]
        public string Likes { get; set; }

        public string PreviewUrl
        {
            get { return Url + "/preview"; }
        }
    }
}