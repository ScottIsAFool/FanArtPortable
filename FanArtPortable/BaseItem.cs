using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable
{
    [ImplementPropertyChanged]
    public abstract class BaseItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("likes")]
        public string Likes { get; set; }

        public string PreviewUrl
        {
            get
            {
                return string.Format("{0}/preview", Url);
            }
        }
    }
}
