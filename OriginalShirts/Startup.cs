using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OriginalShirts.Startup))]
namespace OriginalShirts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
