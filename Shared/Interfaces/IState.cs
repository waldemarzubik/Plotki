using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IState
    {
        Task LoadAsync();

        Task SaveAsync();
    }
}