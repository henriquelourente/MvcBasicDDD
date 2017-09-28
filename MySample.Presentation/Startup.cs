using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySample.Presentation.Startup))]
namespace MySample.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
