public interface IAuthenticationFactory
{
    public IAuthServices GetAuthService(Guid appId);

}
