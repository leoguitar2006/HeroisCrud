using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeroisCRUD.Startup))]
namespace HeroisCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
