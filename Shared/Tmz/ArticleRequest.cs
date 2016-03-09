using Com.Gossip.Shared.Interfaces;

namespace Com.Gossip.Shared.Tmz
{
    public class ArticleRequest : IRequest
    {
        private const string Url = "feed?id={0}";

        public string Id { get; set; }

        public string Uri => string.Format(Url, Id);

        public bool IgnoreCache { get; set; }
    }
}