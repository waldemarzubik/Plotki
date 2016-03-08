using System;
using System.Collections.Generic;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IUriBuilder
    {
        #region Public methods

        string BuildUri(string uri, Dictionary<string, object> parameters = null);

        Uri GetAbsoluteUri(string uri, string baseUri);

        #endregion
    }
}