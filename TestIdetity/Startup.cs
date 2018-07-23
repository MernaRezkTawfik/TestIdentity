using Microsoft.Owin;
using Owin;
//test
[assembly: OwinStartupAttribute(typeof(TestIdetity.Startup))]
namespace TestIdetity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
