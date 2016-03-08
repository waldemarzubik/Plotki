using System;
using System.Net;
using System.Net.Http;
using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.Shared.Response
{
    public class ResponseContainer<T> : IResponse<T>
    {
        #region Ctors

        public ResponseContainer()
            : this(default(T))
        {
        }

        public ResponseContainer(T responseData)
        {
            IsSuccess = true;
            StatusCode = HttpStatusCode.OK;
            ResponseData = responseData;
        }

        #endregion

        #region IResponse<T> Members

        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
        public Uri RequestUrl { get; set; }
        public string ResponseContent { get; set; }
        public T ResponseData { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public bool IsCanceled { get; set; }

        public HttpResponseMessage Response { get; set; }

        #endregion
    }
}