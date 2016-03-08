using System;
using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces.Cache
{
    public interface ICache : IState
    {
        Task<T> GetCachedDataAsync<T>(string token);

        Task RemoveAllAsync();

        Task UpdateCacheDataAsync<T>(T data, string token, DateTime expirationDate) where T : class;
    }
}