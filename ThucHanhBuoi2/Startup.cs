using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThucHanhBuoi2.Startup))]
namespace ThucHanhBuoi2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
