using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeteriaAspx.Startup))]
namespace CafeteriaAspx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
