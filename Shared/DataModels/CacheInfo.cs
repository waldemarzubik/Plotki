using System;
using Com.Gossip.Shared.Interfaces.Cache;

namespace Com.Gossip.Shared.DataModels
{
    public class CacheInfo : ICacheInfo
    {
        public DateTime Date { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string FileName { get; set; }

        public string Token { get; set; }
    }
}