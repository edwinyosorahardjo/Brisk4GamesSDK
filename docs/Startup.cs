using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(docs.Startup))]
namespace docs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
