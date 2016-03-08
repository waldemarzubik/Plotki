using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IAppSettings : IState
    {
        int Version { get; set; }

        T GetValueOrDefault<T>(string key, T defaultValue = default(T));

        Task RemoveAllSettingsAsync();

        void SetVaule<T>(string key, T data);
    }
}