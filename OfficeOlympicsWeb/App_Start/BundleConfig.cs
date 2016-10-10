using System.Web;
using System.Web.Optimization;

namespace OfficeOlympicsWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/jquery.signalR-{version}.js",
                        "~/Scripts/js-cookie/js.cookie.js",
                        "~/Scripts/context-menu.js",
                        "~/Scripts/toast.js",
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").IncludeDirectory(
                        "~/Scripts/Admin", "*.js", searchSubdirectories: false));

            bundles.Add(new ScriptBundle("~/bundles/home-newRecord").IncludeDirectory(
                        "~/Scripts/Home/NewRecord", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/bundles/home-index").IncludeDirectory(
                        "~/Scripts/Home/Index", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/bundles/home-about").IncludeDirectory(
                        "~/Scripts/Home/About", "*.js", searchSubdirectories: true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/toast.css",
                        "~/Content/context-menu.css"));

            bundles.Add(new StyleBundle("~/Content/admin").IncludeDirectory(
                        "~/Content/Admin", "*.css", searchSubdirectories: false));

            bundles.Add(new StyleBundle("~/Content/home-index").IncludeDirectory(
                        "~/Content/Home/Index", "*.css", searchSubdirectories: true));
        }
    }
}
