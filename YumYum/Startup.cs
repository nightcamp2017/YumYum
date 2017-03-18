using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YumYum.Startup))]
namespace YumYum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
