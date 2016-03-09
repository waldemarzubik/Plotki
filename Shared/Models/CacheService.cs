using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Com.Gossip.Shared.Interfaces;
using Com.Gossip.Shared.Interfaces.Cache;
using MvvmCross.Platform;

namespace Com.Gossip.Shared.Models
{
    public class CacheModel : ICache
    {
        #region Ctors

        public CacheModel(IStorage storage, Dictionary<Type, int> requestsCache = null)
        {
            if (storage == null)
            {
                throw new ArgumentException($"Missing {nameof(IStorage)}");
            }
            _storage = storage;
            _requestsCache = requestsCache;
            _semaphore = new SemaphoreSlim(1, 1);
        }

        #endregion

        #region Properties

        private List<ICacheInfo> CacheInfo { get; set; }

        #endregion

        #region Constants

        private const string CacheIndexLocation = "CacheInfo";
        private const string CacheSerializedResponsesLocation = "CachedData";

        #endregion

        #region Private fields

        private readonly SemaphoreSlim _semaphore;
        private readonly IStorage _storage;
        private readonly Dictionary<Type, int> _requestsCache;

        #endregion

        #region Private methods

        private static bool IsExpired(ICacheInfo cacheInfo)
        {
            return cacheInfo.ExpirationDate.HasValue && DateTime.Now.CompareTo(cacheInfo.ExpirationDate.Value) > 0;
        }

        private async Task RemoveExpiredDataAsync()
        {
            foreach (var cacheInfo in new List<ICacheInfo>(CacheInfo.Where(IsExpired)))
            {
                if (!string.IsNullOrEmpty(cacheInfo.FileName))
                {
                    await _storage.DeleteFromStorageAsync(cacheInfo.FileName);
                }
                CacheInfo.Remove(cacheInfo);
            }
        }

        #endregion

        #region ICache Members

        public async Task RemoveAllAsync()
        {
            CacheInfo.Clear();
            await _storage.DeleteFolderFromStorageAsync(Path.GetDirectoryName(CacheSerializedResponsesLocation));
            await SaveAsync();
        }

        public async Task LoadAsync()
        {
            await _storage.CreateFolder(CacheSerializedResponsesLocation);
            CacheInfo = await _storage.LoadDecryptedObjectAsync<List<ICacheInfo>>(CacheIndexLocation) ??
                        new List<ICacheInfo>();
            await RemoveExpiredDataAsync();
        }

        public Task SaveAsync()
        {
            return _storage.SaveCryptedObjectAsync(CacheInfo, CacheIndexLocation);
        }

        public async Task UpdateCacheDataAsync<T, G>(G data, string token) where T : IRequest where G : class
        {
            int cacheExpirationTime;
            if (data == null || _requestsCache == null || !_requestsCache.TryGetValue(typeof (T), out cacheExpirationTime))
            {
                return;
            }
            var expirationDate = DateTime.Now.AddSeconds(cacheExpirationTime);
            if (DateTime.Now.CompareTo(expirationDate) <= 0)
            {
                try
                {
                    await _semaphore.WaitAsync();
                    var cacheInfo = CacheInfo.FirstOrDefault(item => item.Token == token);
                    if (cacheInfo == null)
                    {
                        cacheInfo = Mvx.Resolve<ICacheInfo>();
                        CacheInfo.Add(cacheInfo);
                    }
                    cacheInfo.Token = token;
                    var fileName = Guid.NewGuid().ToString();
                    await _storage.SaveCryptedObjectAsync(data, fileName);
                    cacheInfo.FileName = fileName;
                    cacheInfo.Date = DateTime.Now;
                    cacheInfo.ExpirationDate = expirationDate;
                }
                finally
                {
                    _semaphore.Release();
                }
            }
        }

        public async Task<T> GetCachedDataAsync<T>(string token)
        {
            var data = default(T);
            try
            {
                var cacheInfo = CacheInfo.FirstOrDefault(item => item.Token == token);
                if (cacheInfo != null)
                {
                    if (IsExpired(cacheInfo))
                    {
                        await _storage.DeleteFromStorageAsync(cacheInfo.FileName).ConfigureAwait(false);
                        CacheInfo.Remove(cacheInfo);
                        return default(T);
                    }
                    data = await _storage.LoadDecryptedObjectAsync<T>(cacheInfo.FileName);
                }
            }
            catch (Exception)
            {
                //if anything wrong happened just catch it and return default
            }
            return data;
        }

        #endregion
    }
}