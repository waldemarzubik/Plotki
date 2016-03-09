using System;
using Newtonsoft.Json;

namespace Com.Gossip.Shared.DataModels
{
    public class Thumbnails
    {
        [JsonProperty("imageSmallUrl")]
        public string Small { get; set; }

        [JsonProperty("imageMediumUrl")]
        public string Medium { get; set; }

        [JsonProperty("imageLargeUrl")]
        public string Large { get; set; }
    }
}