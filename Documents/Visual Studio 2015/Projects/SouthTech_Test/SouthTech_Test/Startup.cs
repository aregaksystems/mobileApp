using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SouthTech_Test.Startup))]
namespace SouthTech_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
