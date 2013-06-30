using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FanArtPortable.Movies;
using FanArtPortable.Tv;
using Newtonsoft.Json;

namespace FanArtPortable
{
    public class FanArtClient
    {
        // 22e73311eb84458e36b76023293f16fb

        private const string BaseUrl = "http://api.fanart.tv/webservice/";
        
        private readonly HttpClient _httpClient;

        #region Constructors
        public FanArtClient(HttpMessageHandler handler)
            : this(string.Empty, handler)
        {
        }

        public FanArtClient(string apiKey, HttpMessageHandler handler)
        {
            _httpClient = handler == null
                ? new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
                : new HttpClient(handler);
            ApiKey = apiKey;
        }

        public FanArtClient(string apiKey)
            : this(apiKey, null)
        {
        }

        public FanArtClient()
            : this(string.Empty)
        {
        }
        #endregion

        #region Public properties
        public string ApiKey { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the movie images async.
        /// </summary>
        /// <param name="id">The movie id. This can be an IMDb ID or a TMDb ID.</param>
        /// <param name="imageType">Type of the image. [OPTIONAL]</param>
        /// <param name="sortBy">The sort by. [OPTIONAL]</param>
        /// <param name="limit">The limit. [OPTIONAL]</param>
        /// <returns>
        /// The movie details
        /// </returns>
        /// <exception cref="System.ArgumentNullException">id;The ID cannot be null or empty.</exception>
        public async Task<Movie> GetMovieImagesAsync(string id, MovieImageType imageType = MovieImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "The ID cannot be null or empty.");
            }

            var url = CreateUrl(id, "movie", imageType, sortBy, limit);

            var response = await GetResponse<MovieResponse>(url, true);

            return response.Movie;
        }

        /// <summary>
        /// Gets the tv images.
        /// </summary>
        /// <param name="id">The id of the TV series. This will be thetvdb.com's ID</param>
        /// <param name="imageType">Type of the image. [OPTIONAL]</param>
        /// <param name="sortBy">The sort by. [OPTIONAL]</param>
        /// <param name="limit">The limit. [OPTIONAL]</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id;The ID cannot be null or empty.</exception>
        public async Task<TvResponse> GetTvImagesAsync(string id, TvImageType imageType = TvImageType.All, SortBy sortBy = SortBy.PopularThenNewest, Limit limit = Limit.AllImages)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "The ID cannot be null or empty.");
            }

            var url = CreateUrl(id, "series", imageType, sortBy, limit);

            var response = await GetResponse<TvResponse>(url);

            return response;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <typeparam name="TReturnType">The type of the return type.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="requiresFixedJson">if set to <c>true</c> [requires fixed json].</param>
        /// <returns></returns>
        private async Task<TReturnType> GetResponse<TReturnType>(string url, bool requiresFixedJson = false)
            where TReturnType : class 
        {
            var responseString = await _httpClient.GetStringAsync(url);

            if (requiresFixedJson)
            {
                responseString = responseString.FixJson();
            }

            var item = JsonConvert.DeserializeObject<TReturnType>(responseString);

            return item;
        }

        /// <summary>
        /// Creates the base URL.
        /// </summary>
        /// <param name="apiCall">The API call.</param>
        /// <returns>The base url</returns>
        private string CreateBaseUrl(string apiCall)
        {
            return string.Format("{0}{1}/{2}", BaseUrl, apiCall, ApiKey);
        }

        /// <summary>
        /// Creates the URL.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="apiCall">The API call.</param>
        /// <param name="imageType">Type of the image.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>The url to call</returns>
        private string CreateUrl(string id, string apiCall, Enum imageType, SortBy sortBy, Limit limit)
        {
            var baseUrl = CreateBaseUrl(apiCall);

            return string.Format("{0}/{1}/JSON/{2}/{3}/{4}", baseUrl, id, imageType.ToString().ToLower(), (int)sortBy, (int)limit);
        }
        #endregion
    }
}
