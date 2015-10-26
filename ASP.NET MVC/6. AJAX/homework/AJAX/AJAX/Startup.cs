using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AJAX.Startup))]
namespace AJAX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
