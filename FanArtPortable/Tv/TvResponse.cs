using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Tv
{
    [ImplementPropertyChanged]
    public class TvResponse
    {
        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("clearlogos")]
        public TvItem[] TvItems { get; set; }

        [JsonProperty("cleararts")]
        public TvItem[] Cleararts { get; set; }

        [JsonProperty("tvthumbs")]
        public TvItem[] Tvthumbs { get; set; }

        [JsonProperty("seasonthumbs")]
        public Seasonthumb[] Seasonthumbs { get; set; }
    }
}
