namespace Sequin.ClaimsAuthentication.Owin.Middleware
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Owin;

    public class UnauthorizedCommandResponseMiddleware : OwinMiddleware
    {
        public UnauthorizedCommandResponseMiddleware(OwinMiddleware next) : base(next) {}

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (UnauthorizedCommandException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            }
        }
    }
}