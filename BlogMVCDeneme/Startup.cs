using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogMVCDeneme.Startup))]
namespace BlogMVCDeneme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
