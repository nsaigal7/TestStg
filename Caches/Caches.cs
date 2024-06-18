public class InMemoryCache : ICache
{
    public static Dictionary<string, object> _cacheBoy = new();

    public void AddData(string key, object value)
    {
        _cacheBoy.Add(key, value);
    }

    public object GetData(string key) 
    { 
        if (_cacheBoy.ContainsKey(key))
        {
            Console.WriteLine($"Retrieved {key} from InMemory Cache");
        }
        else
        {
            return null;
        }
        return _cacheBoy[key];
    }
}



public class SmallCache : ICache
{
    public object GetData(string key) => $"Resolving {key} from small cache.";

    public void AddData(string key, object value)
    {    }

}
public class BigCache : ICache
{
    public object GetData(string key) => $"Resolving {key} from BIG cache.";

    public void AddData(string key, object value)
    {    }

}