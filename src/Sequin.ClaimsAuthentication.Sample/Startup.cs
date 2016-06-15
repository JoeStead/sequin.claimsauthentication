namespace Sequin.ClaimsAuthentication.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Configuration;
    using global::Owin;
    using Microsoft.Owin;
    using Owin;
    using Owin.Middleware;
    using Pipeline;
    using Sequin.Owin;
    using Sequin.Owin.Extensions;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Force sign-in with role
            app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
                                                              {
                                                                  var context = new OwinContext(env);
                                                                  var claims = new List<Claim>
                                                                               {
                                                                                   new Claim("role", "SomeRole")
                                                                               };

                                                                  context.Request.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "SomeAuthType"));

                                                                  await next.Invoke(env);
                                                              })));

            app.UseSequin(SequinOptions.Configure()
                                       .WithOwinDefaults()
                                       .WithPipeline(x => new OptOutCommandAuthorization(new OwinIdentityProvider())
                                                          {
                                                              Next = x.IssueCommand
                                                          })
                                       .Build(), new []
                                                 {
                                                     new ResponseMiddleware(typeof (UnauthorizedCommandResponseMiddleware))
                                                 });
        }
    }
}