public interface ICache
{
    public object GetData(string key);
    public void AddData(string key, object value);
}