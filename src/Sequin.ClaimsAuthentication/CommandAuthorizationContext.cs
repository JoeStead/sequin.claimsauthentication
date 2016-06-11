namespace Sequin.ClaimsAuthentication
{
    using System.Security.Claims;

    public class CommandAuthorizationContext
    {
        private readonly ClaimsIdentity identity;

        internal CommandAuthorizationContext(ClaimsIdentity identity)
        {
            this.identity = identity;
        }

        internal void Reject()
        {
            IsAuthorized = false;
        }

        public bool HasClaim(string type, string value)
        {
            return identity != null && identity.HasClaim(type, value);
        }

        public bool IsAuthenticated => identity?.IsAuthenticated ?? false;

        public bool IsAuthorized { get; private set; } = true;
    }
}