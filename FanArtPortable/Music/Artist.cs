using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Music
{
    [ImplementPropertyChanged]
    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }
    }
}