using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotWikiHow_.MVC.Startup))]
namespace NotWikiHow_.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
