public class OAuth : IAuthServices
{
    private ICache _cache;
    public string tokenSeed = string.Empty;
    public OAuth(ICache cache)
    {
        _cache = cache;
    }
    public string GetAuthToken()
    {
        Console.WriteLine("Attempting to get token from " + _cache.GetData("key"));
        return $"OauthToken {tokenSeed}";
    }}