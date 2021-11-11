using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zomato.Startup))]
namespace Zomato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
