using System.Threading.Tasks;

namespace Com.Gossip.Shared.Interfaces
{
    public interface IHttpService
    {
        Task<IResponse<G>> ExecuteOperation<T, G>(T request = default(T))
            where T : IRequest
            where G : class;
    }
}