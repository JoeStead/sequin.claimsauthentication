namespace Sequin.ClaimsAuthentication.Pipeline
{
    using System.Collections.Generic;
    using System.Linq;

    public class OptInCommandAuthorization : CommandAuthorization
    {
        public OptInCommandAuthorization(IIdentityProvider identityProvider) : base(identityProvider) { }

        protected override bool IsAuthorized(CommandAuthorizationContext authorizationContext, IEnumerable<AuthorizeCommandAttribute> authorizationAttributes, bool isExplicitAnonymousCommand)
        {
            var attributes = authorizationAttributes.ToList();

            if (attributes.Any())
            {
                if (!authorizationContext.IsAuthenticated)
                {
                    authorizationContext.Reject();
                }
                else
                {
                    ProcessAuthorizationAttributes(authorizationContext, attributes);
                }
            }

            return authorizationContext.IsAuthorized;
        }
    }
}