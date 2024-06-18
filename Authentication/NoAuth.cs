public class NoAuth : IAuthServices
{
    public string tokenSeed = string.Empty;
    public string GetAuthToken()
    {
        return $"NoAuth {tokenSeed}";
    }
}