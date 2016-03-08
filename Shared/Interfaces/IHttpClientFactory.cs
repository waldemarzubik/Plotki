using System.Net.Http;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient GetHttpClient();
    }
}