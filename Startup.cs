using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeAssign.Startup))]
namespace CodeAssign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
