using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pet_Shop.Startup))]
namespace Pet_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
