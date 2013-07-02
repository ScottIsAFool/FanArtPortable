using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Movies
{
    [ImplementPropertyChanged]
    public class MovieResponse
    {
        [JsonProperty("Item")]
        public Movie Movie { get; set; }
    }

}
