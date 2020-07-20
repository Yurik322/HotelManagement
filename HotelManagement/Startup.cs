using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManagement.Startup))]
namespace HotelManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
