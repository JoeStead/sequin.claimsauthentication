namespace Sequin.ClaimsAuthentication
{
    using System.Security.Claims;

    public interface IIdentityProvider
    {
        ClaimsIdentity Get();
    }
}