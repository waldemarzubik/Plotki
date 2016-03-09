namespace Com.Gossip.Shared.Interfaces
{
    public interface IContentRequest : IRequest
    {
        #region Public methods

        string GetRequestContent(IUriBuilder builder);

        #endregion
    }
}