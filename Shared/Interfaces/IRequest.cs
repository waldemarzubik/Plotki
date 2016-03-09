namespace Com.Gossip.Shared.Interfaces
{
    public interface IRequest
    {
        string Uri { get; }

        bool IgnoreCache { get; set; }
    }
}