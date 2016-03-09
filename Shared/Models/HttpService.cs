using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Com.Gossip.Shared.Interfaces;
using Com.Gossip.Shared.Response;

namespace Com.Gossip.Shared.Models
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentException($"Missing {nameof(IHttpClientFactory)}");
            }
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse<T>> ExecuteRequest<T>(string uri, HttpContent httpContent = null)
        {
            HttpResponseMessage httpResponse = null;
            var response = new ResponseContainer<T>();
            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    throw new HttpRequestException();
                }
                using (var httpClient = _httpClientFactory.GetHttpClient())
                {
                    if (httpContent != null)
                    {
                        httpResponse = await httpClient.PostAsync(uri, httpContent);
                    }
                    else
                    {
                        httpResponse = await httpClient.GetAsync(uri);
                    }
                    response.ResponseContent = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                response.Exception = ex;
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.IsSuccess = false;
            }
            if (httpResponse != null)
            {
                response.StatusCode = response.StatusCode;
            }
            return response;
        }
    }
}