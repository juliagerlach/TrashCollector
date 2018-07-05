using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashcollectorProject.Startup))]
namespace TrashcollectorProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
