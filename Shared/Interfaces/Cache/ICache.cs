using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces.Cache
{
    public interface ICache : IState
    {
        Task<T> GetCachedDataAsync<T>(string token);

        Task RemoveAllAsync();

        Task UpdateCacheDataAsync<T, G>(G data, string token) where T : IRequest where G : class;
    }
}