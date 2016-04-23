using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakerPlatform.Startup))]
namespace MakerPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
