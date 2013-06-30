using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FanArtPortable
{
    public abstract class BaseClient
    {
        // 22e73311eb84458e36b76023293f16fb

        protected const string BaseUrl = "http://api.fanart.tv/webservice/";
        
        private readonly HttpClient _httpClient;

        #region Constructors
        protected BaseClient(HttpMessageHandler handler)
            : this(string.Empty, handler)
        {
        }

        protected BaseClient(string apiKey, HttpMessageHandler handler)
        {
            _httpClient = handler == null
                ? new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
                : new HttpClient(handler);
            ApiKey = apiKey;
        }

        protected BaseClient(string apiKey)
            : this(apiKey, null)
        {
        }

        protected BaseClient()
            : this(string.Empty)
        {
        }
        #endregion

        #region Public properties
        public string ApiKey { get; set; }
        
        abstract public string ApiTypeBase { get; }

        public string Url
        {
            get { return string.Format("{0}{1}/{2}/", BaseUrl, ApiTypeBase, ApiKey); }
        }
        #endregion

        #region Private methods
        protected async Task<T> GetResponse<T>(string url, bool requiresFixedJson = false) 
            where T : class 
        {
            var responseString = await _httpClient.GetStringAsync(url);

            if (requiresFixedJson)
            {
                responseString = responseString.FixJson();
            }

            var item = JsonConvert.DeserializeObject<T>(responseString);

            return item;
        }

        protected string CreateUrl(string id, Enum imageType, SortBy sortBy, Limit limit)
        {
            return string.Format("{0}/{1}/JSON/{2}/{3}/{4}", Url, id, imageType.ToString().ToLower(), (int)sortBy, (int)limit);
        }
        #endregion
    }
}
