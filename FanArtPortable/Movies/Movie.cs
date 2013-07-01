using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Movies
{
    [ImplementPropertyChanged]
    public class Movie
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Details")]
        public MovieDetails MovieDetails { get; set; }
    }
}