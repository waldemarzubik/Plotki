using System;

namespace Com.Gossip.Shared.Interfaces.Cache
{
    public interface ICacheInfo
    {
        DateTime Date { get; set; }

        DateTime? ExpirationDate { get; set; }

        string FileName { get; set; }

        string Token { get; set; }
    }
}