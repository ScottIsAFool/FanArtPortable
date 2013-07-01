using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Movies
{
    [ImplementPropertyChanged]
    public class MovieDetails
    {
        [JsonProperty("tmdb_id")]
        public string TmdbId { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("movielogo")]
        public MovieItem[] MovieItem { get; set; }

        [JsonProperty("moviedisc")]
        public Moviedisc[] Moviedisc { get; set; }

        [JsonProperty("movieart")]
        public MovieItem[] Movieart { get; set; }

        [JsonProperty("moviebackground")]
        public MovieItem[] Moviebackground { get; set; }

        [JsonProperty("hdmovielogo")]
        public MovieItem[] Hdmovielogo { get; set; }

        [JsonProperty("moviebanner")]
        public MovieItem[] Moviebanner { get; set; }

        [JsonProperty("hdmovieclearart")]
        public MovieItem[] Hdmovieclearart { get; set; }
    }
}