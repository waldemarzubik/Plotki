using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.Shared.Tmz
{
    public class ArticlesRequest : IRequest
    {
        private const string Url = "feed/tmz";

        public string Uri => Url;

        public bool IgnoreCache { get; set; }
    }
}