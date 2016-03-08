using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IApplicationState
    {
        Task LoadAsync();

        Task SaveAsync();
    }
}