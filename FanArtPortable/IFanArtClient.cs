using System.Threading.Tasks;
using FanArtPortable.Movies;
using FanArtPortable.Music;
using FanArtPortable.Tv;

namespace FanArtPortable
{
    public interface IFanArtClient
    {
        string ApiKey { get; set; }

        /// <summary>
        /// Gets the movie images async.
        /// </summary>
        /// <param name="movieId">The movie id. This can be an IMDb ID or a TMDb ID.</param>
        /// <param name="imageType">Type of the image. [OPTIONAL]</param>
        /// <param name="sortBy">The sort by. [OPTIONAL]</param>
        /// <param name="limit">The limit. [OPTIONAL]</param>
        /// <returns>
        /// The movie details
        /// </returns>
        /// <exception cref="System.ArgumentNullException">id;The ID cannot be null or empty.</exception>
        Task<Movie> GetMovieImagesAsync(string movieId, MovieImageType imageType = MovieImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages);

        /// <summary>
        /// Gets the tv images.
        /// </summary>
        /// <param name="seriesId">The id of the TV series. This will be thetvdb.com's ID</param>
        /// <param name="imageType">Type of the image. [OPTIONAL]</param>
        /// <param name="sortBy">The sort by. [OPTIONAL]</param>
        /// <param name="limit">The limit. [OPTIONAL]</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id;The ID cannot be null or empty.</exception>
        Task<TvResponse> GetTvImagesAsync(string seriesId, TvImageType imageType = TvImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages);

        Task<Artist> GetArtistImagesAsync(string artistId, MusicImageType imageType = MusicImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages);
        Task<Artist> GetAlbumImagesAsync(string albumId, MusicImageType imageType = MusicImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages);
    }
}