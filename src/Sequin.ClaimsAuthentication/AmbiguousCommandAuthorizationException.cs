namespace Sequin.ClaimsAuthentication
{
    using System;

    public class AmbiguousCommandAuthorizationException : Exception
    {
        internal AmbiguousCommandAuthorizationException(Type commandType) : base($"Command '{commandType.Name}' has ambiguous authorization configuration")
        {
            CommandType = commandType;
        }

        public Type CommandType { get; }
    }
}