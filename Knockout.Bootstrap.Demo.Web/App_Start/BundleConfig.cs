using System.Web;
using System.Web.Optimization;

namespace Knockout.Bootstrap.Demo.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css",
                "~/Content/highlight.css"
                            ));

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.binding-conventions-{version}.js",
                "~/Scripts/knockout.bootstrap-{version}.js",
                "~/Scripts/knockout.mapping-latest.js",
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/rainbow-custom.js"
                            ));

            bundles.Add(new ScriptBundle("~/bundles/site").IncludeDirectory("~/Scripts/site", "*.js", true));
        }
    }
}