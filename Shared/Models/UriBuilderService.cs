using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.Shared.Models
{
    public class UriBuilderService : IUriBuilder
    {
        #region Private methods

        private UriBuilder AddParam(UriBuilder uriBuilder, string key, object value)
        {
            const string firstParamFormat = "{0}={1}";
            const string arrayFirstParamFormat = "{1}";
            const string paramFormat = "&{0}={1}";
            const string arrayParamFormat = "&{0}[]={1}";
            const string paramNoValueFormat = "&{0}";
            const string paramsSeparator = "?";
            const string itemSeparator = ",";

            var isArrayParamType = false;
            string valueStr = null;
            var array = value as Array;
            var enumerable = value as IList;
            if (array != null)
            {
                isArrayParamType = true;
                valueStr = array.Cast<object>()
                    .Aggregate(valueStr, (current, item) => current + string.Format(arrayParamFormat, key, item));
                valueStr = valueStr?.Remove(0, 1);
            }
            else if (enumerable != null)
            {
                valueStr = enumerable.Cast<object>()
                    .Aggregate(valueStr, (current, item) => current + (item + itemSeparator));
                valueStr = valueStr?.Remove(valueStr.Length - 1, 1);
            }
            else
            {
                valueStr = value != null ? value.ToString() : string.Empty;
            }
            if (string.IsNullOrEmpty(uriBuilder.Query))
            {
                if (!string.IsNullOrEmpty(valueStr))
                {
                    uriBuilder.Query = string.Format(isArrayParamType ? arrayFirstParamFormat : firstParamFormat,
                        Uri.EscapeUriString(key),
                        Uri.EscapeUriString(valueStr));
                }
                else
                {
                    uriBuilder.Query = Uri.EscapeUriString(key);
                }
                return uriBuilder;
            }
            var query = uriBuilder.Query;
            if (query.StartsWith(paramsSeparator))
            {
                query = query.Substring(1);
            }
            if (!string.IsNullOrEmpty(valueStr))
            {
                uriBuilder.Query = query +
                                   string.Format(isArrayParamType ? paramNoValueFormat : paramFormat,
                                       Uri.EscapeUriString(key),
                                       Uri.EscapeUriString(valueStr));
            }
            else
            {
                uriBuilder.Query = query +
                                   string.Format(paramNoValueFormat, Uri.EscapeUriString(key));
            }
            return uriBuilder;
        }


        private string GetRelativeUri(UriBuilder uriBuilder)
        {
            const string separator = "/";

            var path = uriBuilder.Path;
            if (uriBuilder.Path != null &&
                uriBuilder.Path.EndsWith(separator))
            {
                path = uriBuilder.Path.Substring(1);
            }
            return path + uriBuilder.Query;
        }

        #endregion

        #region IUriBuilder Members

        public string BuildUri(string uri, Dictionary<string, object> parameters = null)
        {
            var uriBuilder = new UriBuilder {Path = uri};
            if (parameters != null)
            {
                uriBuilder = parameters.Aggregate(uriBuilder, (current, kvp) => AddParam(current, kvp.Key, kvp.Value));
            }
            return GetRelativeUri(uriBuilder);
        }

        public Uri GetAbsoluteUri(string uri, string baseUri)
        {
            if (!string.IsNullOrEmpty(baseUri))
            {
                return new Uri(baseUri + uri, UriKind.Absolute);
            }
            return new Uri(uri, UriKind.Absolute);
        }

        #endregion
    }
}