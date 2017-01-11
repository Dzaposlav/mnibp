using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nmibp2lab.Startup))]
namespace nmibp2lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
