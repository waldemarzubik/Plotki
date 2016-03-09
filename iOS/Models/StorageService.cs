using System;
using System.Threading.Tasks;
using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.iOS.Models
{
    public class StorageService : IStorage
    {
        public Task<bool> ContainsFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<T> LoadDecryptedObjectAsync<T>(string fileName, Type[] knownTypes = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> LoadObjectAsync<T>(string fileName, Type[] knownTypes = null)
        {
            throw new NotImplementedException();
        }

        public Task SaveCryptedObjectAsync<T>(T obj, string fileName, Type[] knownTypes = null)
        {
            throw new NotImplementedException();
        }

        public Task SaveObjectAsync<T>(T obj, string fileName, Type[] knownTypes = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFolderFromStorageAsync(string folderName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromStorageAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task CreateFolder(string path)
        {
            throw new NotImplementedException();
        }
    }
}