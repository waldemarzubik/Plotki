using System.Net.Http;
using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IHttpService
    {
        Task<IResponse<T>> ExecuteRequest<T>(string uri, HttpContent httpContent = null);
    }
}