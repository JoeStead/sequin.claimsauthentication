namespace Sequin.ClaimsAuthentication.Sample.Commands
{
    using System.Threading.Tasks;

    public class MyAnonymousCommandHandler : IHandler<MyAnonymousCommand>
    {
        public Task Handle(MyAnonymousCommand command)
        {
            return Task.FromResult(0);
        }
    }
}