public class AuthenticationFactory: IAuthenticationFactory
{
    private readonly ICache _cache;
    public AuthenticationFactory(ICache cache)
    {
        _cache = cache;
    }
    public IAuthServices GetAuthService(
        Guid appId)
    {
        int intappId = GuidToInt(appId) % 3;
        Console.WriteLine($"{appId} -> {intappId}");
        return intappId switch
        {
            0 => new OAuth(_cache),
            1 => new Jwt(),
            2 => new UsernamePassword(),
            _ => new NoAuth(),
        };
    }
    private int GuidToInt(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        // Extract the first 4 bytes and convert them to an int
        int intRepresentation = BitConverter.ToInt32(bytes, 0);
        return intRepresentation;
    }
}
