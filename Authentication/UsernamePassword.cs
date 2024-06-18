public class UsernamePassword : IAuthServices
{
    public string tokenSeed = string.Empty;
    public string GetAuthToken()
    {
        return $"UsernamePassword {tokenSeed}";
    }
}