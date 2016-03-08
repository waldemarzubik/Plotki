namespace Com.Gossip.Shared.Interfaces
{
    public interface IJsonSerializer
    {
        T Deserialize<T>(string content);

        string Serialize<T>(T data);
    }
}