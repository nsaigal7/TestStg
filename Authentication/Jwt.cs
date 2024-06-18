public class Jwt : IAuthServices
{
    public string tokenSeed = Guid.NewGuid().ToString();
    public string GetAuthToken()
    {
        return $"JwtToken {tokenSeed}";
    }
}