using System;
using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IStorage
    {
        Task<bool> ContainsFileAsync(string fileName);

        Task<T> LoadDecryptedObjectAsync<T>(string fileName, Type[] knownTypes = null);

        Task<T> LoadObjectAsync<T>(string fileName, Type[] knownTypes = null);

        Task SaveCryptedObjectAsync<T>(T obj, string fileName, Type[] knownTypes = null);

        Task SaveObjectAsync<T>(T obj, string fileName, Type[] knownTypes = null);

        Task DeleteFolderFromStorageAsync(string folderName);

        Task DeleteFromStorageAsync(string fileName);

        Task CreateFolder(string path);
    }
}