namespace Com.Gossip.Shared.Interfaces
{
    public interface IJsonContentRequest : IRequest
    {
        #region Public methods

        string GetContent(IJsonSerializer serializer);

        #endregion
    }
}