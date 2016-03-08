namespace Com.Gossip.Shared.Interfaces
{
    public interface IRequest
    {
        string Url { get; }

        bool IgnoreCache { get; set; }
    }
}