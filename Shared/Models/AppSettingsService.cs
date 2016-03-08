using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.Shared.Models
{
    public class AppSettingsService : IAppSettings
    {
        #region Private fields

        #endregion

        #region Ctors

        public AppSettingsService(IList<Type> knownTypes = null, int version = 1)
        {
            Version = version;
            KnownTypes = knownTypes;
        }

        #endregion

        #region Constants

        private const string FileName = "Settings";
        private const string VersionFileName = "Version";

        #endregion

        #region Properties

        private Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        private IList<Type> KnownTypes { get; }

        #endregion

        #region IAppSettings Members

        public int Version { get; set; }

        public T GetValueOrDefault<T>(string key, T defaultValue = default(T))
        {
            if (Data.ContainsKey(key))
            {
                return (T) Data[key];
            }
            return defaultValue;
        }

        public async Task RemoveAllSettingsAsync()
        {
            Data.Clear();
            await SaveAsync();
        }

        public async Task LoadAsync()
        {
            //Data = await
            //    Storage.LoadDecryptedObjectAsync<Dictionary<string, object>>(
             //       FILE_NAME, KnownTypes.ToArray()) ?? new Dictionary<string, object>();
        }

        public async Task SaveAsync()
        {
           // await Storage.SaveCryptedObjectAsync(Data, FILE_NAME, KnownTypes.ToArray());
          //  if (!Version.Equals(default(int)))
          //  {
          //      await Storage.SaveObjectAsync(Version, VERSION_FILE_NAME);
          //  }
        }

        public void SetVaule<T>(string key, T data)
        {
            if (!Data.ContainsKey(key))
            {
                Data.Add(key, data);
                return;
            }
            Data[key] = data;
        }

        #endregion
    }
}