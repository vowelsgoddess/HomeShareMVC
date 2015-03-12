using System.Web;
using System.Web.Optimization;

namespace HomeShareMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/Assets/js").Include(
                    "~/Assets/script.js"));
            bundles.Add(new ScriptBundle("~/Assets/bootstrap").Include(
                    "~/Assets/bootstrap/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/Assets/owl-carousel").Include(
                    "~/Assets/owl-carousel/owl.carousel.js"));
            bundles.Add(new ScriptBundle("~/Assets/slitslider").Include(
                    "~/Assets/slitslider/js/jquery.ba-cond.min.js",
                    "~/Assets/slitslider/js/jquery.slitslider.js",
                    "~/Assets/slitslider/js/modernizr.custom.79639.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/extra.css",
                      "~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Assets/bootstrap").Include(
                      "~/Assets/bootstrap/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Assets/owl-carousel").Include(
                      "~/Assets/owl-carousel/owl.carousel.css",
                      "~/Assets/owl-carousel/owl.theme.css"));
            bundles.Add(new StyleBundle("~/Assets/slitslider").Include(
                      "~/Assets/slitslider/css/custom.css",
                      "~/Assets/slitslider/css/style.css"));
                      
            
        }
    }
}
