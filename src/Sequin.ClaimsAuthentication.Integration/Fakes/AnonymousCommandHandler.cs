namespace Sequin.ClaimsAuthentication.Integration.Fakes
{
    using System.Threading.Tasks;

    public class AnonymousCommandHandler : IHandler<AnonymousCommand>
    {
        public Task Handle(AnonymousCommand command)
        {
            return Task.FromResult(0);
        }
    }
}
