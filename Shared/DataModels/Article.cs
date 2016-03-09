using Newtonsoft.Json;
using System;

namespace Com.Gossip.Shared.DataModels
{
    public class Article
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("downloadDate")]
        public DateTime DownloadDate { get; set; }

        [JsonProperty("hasGallery")]
        public bool HasGallery { get; set; }

        [JsonProperty("hasVideo")]
        public bool HasVideo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("lead")]
        public string Lead { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("publishedDate")]
        public DateTime DublishedDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}