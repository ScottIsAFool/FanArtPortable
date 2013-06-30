using System.Threading.Tasks;

namespace FanArtPortable.Movie
{
    public class FanArtMovieClient : BaseClient
    {
        public override string ApiTypeBase
        {
            get { return "movie"; }
        }

        public async Task<Movie> GetMovieImagesAsync()
        {

            return default(Movie);
        }
    }
}
