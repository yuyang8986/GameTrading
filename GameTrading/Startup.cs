using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameTrading.Startup))]
namespace GameTrading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
