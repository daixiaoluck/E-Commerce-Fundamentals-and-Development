using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Commerce_Project_Three.Startup))]
namespace E_Commerce_Project_Three
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
