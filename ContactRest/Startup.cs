using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ContactRest.Startup))]

namespace ContactRest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}