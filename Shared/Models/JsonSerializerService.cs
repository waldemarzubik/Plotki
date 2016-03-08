using System;
using Com.Gossip.Shared.Interfaces;
using Newtonsoft.Json;

namespace Com.Gossip.Shared.Models
{
    public class JsonSerializerService : IJsonSerializer
    {
        public T Deserialize<T>(string content)
        {
            var result = default(T);
            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    result = JsonConvert.DeserializeObject<T>(content);
                }
                catch (Exception)
                {
                }
            }
            return result;
        }

        public string Serialize<T>(T data)
        {
            var result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(data);
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}