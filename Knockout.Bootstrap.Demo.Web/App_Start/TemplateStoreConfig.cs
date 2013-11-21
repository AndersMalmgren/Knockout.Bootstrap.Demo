using Knockout.Bootstrap.Demo.Web.App_Start;
using Knockout.Bootstrap.TemplateStore.SystemWeb.Owin;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TemplateStoreConfig))]
namespace Knockout.Bootstrap.Demo.Web.App_Start
{
    public static class TemplateStoreConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.InitTemplateStore();
        }
    }
}