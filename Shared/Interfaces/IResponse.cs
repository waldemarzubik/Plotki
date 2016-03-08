using System;
using System.Net;
using System.Net.Http;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IResponse<T>
    {
        #region Properties

        string ErrorMessage { get; set; }

        Exception Exception { get; set; }

        bool IsCanceled { get; set; }

        bool IsSuccess { get; set; }

        Uri RequestUrl { get; set; }

        HttpResponseMessage Response { get; set; }

        string ResponseContent { get; set; }

        T ResponseData { get; set; }

        HttpStatusCode? StatusCode { get; set; }

        #endregion
    }
}