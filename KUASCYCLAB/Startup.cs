using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KUASCYCLAB.Startup))]
namespace KUASCYCLAB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
