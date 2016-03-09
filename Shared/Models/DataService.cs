using System;
using System.Net;
using System.Threading.Tasks;
using Com.Gossip.Shared.Interfaces;
using Com.Gossip.Shared.Interfaces.Cache;
using Com.Gossip.Shared.Response;

namespace Com.Gossip.Shared.Models
{
    public class DataService : IDataService
    {
        private readonly ICache _cache;
        private readonly IHttpService _httpService;
        private readonly IJsonSerializer _serializer;
        private readonly IUriBuilder _uriBuilder;

        public DataService(IUriBuilder uriBuilder, IHttpService httpService, IJsonSerializer serializer,
            ICache cache = null)
        {
            if (uriBuilder == null)
            {
                throw new ArgumentException($"Missing {nameof(IUriBuilder)}");
            }
            if (httpService == null)
            {
                throw new ArgumentException($"Missing {nameof(IHttpService)}");
            }
            _uriBuilder = uriBuilder;
            _httpService = httpService;
            _serializer = serializer;
            _cache = cache;
        }


        public Task<IResponse<string>> ExecuteOperation<T>(T request = default(T)) where T : IRequest, new()
        {
            return ExecuteOperation<T, string>(request);
        }

        public async Task<IResponse<G>> ExecuteOperation<T, G>(T request = default(T)) where T : IRequest, new()
            where G : class
        {
            if (request == null)
            {
                request = new T();
            }
            var uri = _uriBuilder.BuildUri(request.Uri);
            if (_cache != null && !request.IgnoreCache)
            {
                var cacheData = await _cache.GetCachedDataAsync<G>(uri);
                if (cacheData != default(G))
                {
                    return new ResponseContainer<G>(cacheData);
                }
            }
            var response = await _httpService.ExecuteRequest<G>(uri);
            if (response.IsSuccess)
            {
                var rawResponse = response.ResponseContent;
                var data = typeof (G) == typeof (string) ? rawResponse as G : _serializer.Deserialize<G>(rawResponse);
                response.ResponseData = data;
                if (_cache != null && data != null && response.StatusCode == HttpStatusCode.OK)
                {
                    await _cache.UpdateCacheDataAsync<T, G>(data, uri).ConfigureAwait(false);
                }
            }
            return response;
        }
    }
}