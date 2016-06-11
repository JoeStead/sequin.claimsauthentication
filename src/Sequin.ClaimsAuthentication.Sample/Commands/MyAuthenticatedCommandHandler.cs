namespace Sequin.ClaimsAuthentication.Sample.Commands
{
    using System.Threading.Tasks;

    public class MyAuthenticatedCommandHandler : IHandler<MyAuthenticatedCommand>
    {
        public Task Handle(MyAuthenticatedCommand command)
        {
            return Task.FromResult(0);
        }
    }
}