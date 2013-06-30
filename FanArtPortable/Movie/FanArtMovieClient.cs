using System.Threading.Tasks;

namespace FanArtPortable.Movie
{
    public class FanArtMovieClient : BaseClient
    {
        /// <summary>
        /// Gets the API type base.
        /// </summary>
        /// <value>
        /// The API type base.
        /// </value>
        public override string ApiTypeBase
        {
            get { return "movie"; }
        }

        /// <summary>
        /// Gets the movie images async.
        /// </summary>
        /// <param name="id">The movie id. This can be an IMDb ID or a TMDb ID.</param>
        /// <param name="imageType">Type of the image. [OPTIONAL]</param>
        /// <param name="sortBy">The sort by. [OPTIONAL]</param>
        /// <param name="limit">The limit. [OPTIONAL]</param>
        /// <returns>The movie details</returns>
        public async Task<Movie> GetMovieImagesAsync(string id, MovieImageType imageType = MovieImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages)
        {
            var url = CreateUrl(id, imageType, sortBy, limit);
            
            var response = await GetResponse<MovieResponse>(url, true);

            return response.Movie;
        }
    }
}
