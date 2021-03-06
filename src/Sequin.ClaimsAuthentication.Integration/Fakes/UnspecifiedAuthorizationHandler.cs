﻿namespace Sequin.ClaimsAuthentication.Integration.Fakes
{
    using System.Threading.Tasks;

    public class UnspecifiedAuthorizationHandler : IHandler<UnspecifiedAuthorization>
    {
        public Task Handle(UnspecifiedAuthorization command)
        {
            return Task.FromResult(0);
        }
    }
}
