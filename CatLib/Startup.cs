using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatLib.Startup))]
namespace CatLib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
