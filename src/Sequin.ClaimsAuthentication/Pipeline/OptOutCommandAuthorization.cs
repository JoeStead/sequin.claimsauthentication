namespace Sequin.ClaimsAuthentication.Pipeline
{
    using System.Collections.Generic;

    public class OptOutCommandAuthorization : CommandAuthorization
    {
        public OptOutCommandAuthorization(IIdentityProvider identityProvider) : base(identityProvider) { }
        
        protected override bool IsAuthorized(CommandAuthorizationContext authorizationContext, IEnumerable<AuthorizeCommandAttribute> authorizationAttributes, bool isExplicitAnonymousCommand)
        {
            if (!isExplicitAnonymousCommand)
            {
                if (!authorizationContext.IsAuthenticated)
                {
                    authorizationContext.Reject();
                }
                else
                {
                    ProcessAuthorizationAttributes(authorizationContext, authorizationAttributes);
                }
            }

            return authorizationContext.IsAuthorized;
        }
    }
}
