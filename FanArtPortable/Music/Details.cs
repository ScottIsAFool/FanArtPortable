using System.Collections.Generic;
using Newtonsoft.Json;
using PropertyChanged;

namespace FanArtPortable.Music
{
    [ImplementPropertyChanged]
    public class Details
    {
        [JsonProperty("mbid_id")]
        public string MbId { get; set; }

        [JsonProperty("musiclogo")]
        public List<ArtistItem> MusicLogo { get; set; }

        [JsonProperty("artistbackground")]
        public List<ArtistItem> ArtistBackground { get; set; }

        [JsonProperty("artistthumb")]
        public List<ArtistItem> ArtistThumb { get; set; }

        public List<Album> AllAlbums { get; set; }

        [JsonProperty("hdmusiclogo")]
        public List<ArtistItem> HdMusicLogo { get; set; }

        [JsonProperty("musicbanner")]
        public List<ArtistItem> MusicBanner { get; set; }
    }
}