using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Form113.Startup))]
namespace Form113
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
