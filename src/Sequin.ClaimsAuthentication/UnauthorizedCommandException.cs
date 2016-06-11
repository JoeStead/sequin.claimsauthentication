namespace Sequin.ClaimsAuthentication
{
    using System;

    public class UnauthorizedCommandException : Exception
    {
        internal UnauthorizedCommandException(Type commandType) : base($"Command '{commandType.Name}' could not be authorized.")
        {
            CommandType = commandType;
        }

        public Type CommandType { get; }
    }
}