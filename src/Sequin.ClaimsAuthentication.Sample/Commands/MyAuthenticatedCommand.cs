namespace Sequin.ClaimsAuthentication.Sample.Commands
{
    using Core;

    [AuthorizeCommand("SomeRole")]
    public class MyAuthenticatedCommand
    {
        public int PropertyA { get; set; }
        public int PropertyB { get; set; }
    }
}