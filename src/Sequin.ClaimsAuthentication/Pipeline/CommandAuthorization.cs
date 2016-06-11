namespace Sequin.ClaimsAuthentication.Pipeline
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Sequin.Pipeline;

    public abstract class CommandAuthorization : CommandPipelineStage
    {
        private readonly IIdentityProvider identityProvider;

        protected CommandAuthorization(IIdentityProvider identityProvider)
        {
            this.identityProvider = identityProvider;
        }

        protected override Task Process<TCommand>(TCommand command)
        {
            var identity = identityProvider.Get();
            var authorizationContext = new CommandAuthorizationContext(identity);
            var commandType = typeof(TCommand);

            var isExplicitAnonymousCommand = IsExplicitAnonymousCommand(commandType);
            var authorizationAttributes = GetAuthorizationAttributes(commandType);

            if (isExplicitAnonymousCommand && authorizationAttributes.Any())
            {
                throw new AmbiguousCommandAuthorizationException(commandType);
            }

            if (!IsAuthorized(authorizationContext, authorizationAttributes, isExplicitAnonymousCommand))
            {
                throw new UnauthorizedCommandException(commandType);
            }

            return Task.FromResult(0);
        }

        protected abstract bool IsAuthorized(CommandAuthorizationContext authorizationContext, IEnumerable<AuthorizeCommandAttribute> authorizationAttributes, bool isExplicitAnonymousCommand);

        protected static void ProcessAuthorizationAttributes(CommandAuthorizationContext authorizationContext, IEnumerable<AuthorizeCommandAttribute> authorizationAttributes)
        {
            foreach (var attribute in authorizationAttributes)
            {
                attribute.Authorize(authorizationContext);
            }
        }

        private static bool IsExplicitAnonymousCommand(Type commandType)
        {
            return commandType.GetCustomAttributes(typeof(AnonymousCommandAttribute), true).Length > 0;
        }

        private static AuthorizeCommandAttribute[] GetAuthorizationAttributes(Type commandType)
        {
            return commandType.GetCustomAttributes(typeof(AuthorizeCommandAttribute), true).Cast<AuthorizeCommandAttribute>().ToArray();
        }
    }
}
