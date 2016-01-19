﻿namespace Sample.Web.ClaimsAuthentication.Commands
{
    using Sequin.ClaimsAuthentication.Core;

    [AuthorizeCommand("SomeRole")]
    public class MyAuthenticatedCommand
    {
        public int PropertyA { get; set; }
        public int PropertyB { get; set; }
    }
}