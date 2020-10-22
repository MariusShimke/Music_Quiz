using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasementHoofersQuiz.Startup))]
namespace BasementHoofersQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
