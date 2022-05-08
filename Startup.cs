using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentComp.Startup))]
namespace StudentComp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
