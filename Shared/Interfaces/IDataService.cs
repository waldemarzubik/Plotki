using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IDataService
    {
        Task<IResponse<string>> ExecuteOperation<T>(T request = default(T))
            where T : IRequest, new();

        Task<IResponse<G>> ExecuteOperation<T, G>(T request = default(T))
            where T : IRequest, new()
            where G : class;
    }
}