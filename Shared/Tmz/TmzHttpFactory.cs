using System;
using System.Net.Http;
using Com.Gossip.Shared.Interfaces;
using ModernHttpClient;
using System.Net.Http.Headers;

namespace Com.Gossip.Shared.Tmz
{
    public class TmzHttpFactory : IHttpClientFactory
    {
        private const string AcceptHeader = "application/json";
        private const string ApiKeyHeader = "X-ZUMO-APPLICATION";
        private const string ApiKeyHeaderV = "etKqRgRkSOkwEYiANGDmsvGAumjRev76";
        private const string BaseAddress = "https://rssnewsservice.azure-mobile.net/api/";

        public HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.BaseAddress = new Uri(BaseAddress, UriKind.Absolute);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ApiKeyHeader, ApiKeyHeaderV);
            return httpClient;
        }
    }
}