using System.Collections.Generic;
using Newtonsoft.Json;

namespace FanArtPortable.Music
{
    public class Album
    {
        [JsonProperty("albumcover")]
        public List<ArtistItem> AlbumCover { get; set; }

        [JsonProperty("cdart")]
        public List<CdArt> CdArt { get; set; }

        public string Id { get; set; }
    }
}