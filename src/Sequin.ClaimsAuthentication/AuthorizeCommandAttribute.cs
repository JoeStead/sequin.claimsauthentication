namespace Sequin.ClaimsAuthentication
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class AuthorizeCommandAttribute : Attribute
    {
        private readonly string[] requiredRoles;

        public AuthorizeCommandAttribute(params string[] requiredRoles)
        {
            this.requiredRoles = requiredRoles;
        }

        internal void Authorize(CommandAuthorizationContext context)
        {
            if (requiredRoles.Any(role => !context.HasClaim("role", role)))
            {
                context.Reject();
            }
        }
    }
}