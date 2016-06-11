namespace Sequin.ClaimsAuthentication.Owin
{
    using System.Security.Claims;
    using global::Owin;
    using Microsoft.Owin;

    public class OwinIdentityProvider : IIdentityProvider
    {
        public ClaimsIdentity Get()
        {
            var context = new OwinContext(OwinRequestScopeContext.Current.Environment);
            return (ClaimsIdentity) context.Authentication.User?.Identity;
        }
    }
}
