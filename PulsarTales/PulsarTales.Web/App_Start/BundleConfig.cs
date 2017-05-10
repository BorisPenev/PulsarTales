using System.Web;
using System.Web.Optimization;

namespace PulsarTales.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js", 
                      "~/Scripts/respond.js"));
            
            // Froala Editor JS
            bundles.Add(new ScriptBundle("~/bundles/froala-editor").Include(
                     "~/Scripts/froala-editor/js/froala_editor.min.js",
                     "~/Scripts/froala-editor/js/languages/en_gb.js",
                     "~/Scripts/froala-editor/js/plugins/code_beautifier.min.js", 
                     "~/Scripts/froala-editor/js/plugins/code_view.min.js",
                     "~/Scripts/froala-editor/js/plugins/colors.min.js",
                     "~/Scripts/froala-editor/js/plugins/emoticons.min.js",
                     "~/Scripts/froala-editor/js/plugins/font_family.min.js",
                     "~/Scripts/froala-editor/js/plugins/font_size.min.js",
                     "~/Scripts/froala-editor/js/plugins/table.min.js",
                     "~/Scripts/froala-editor/js/plugins/lists.min.js",
                     "~/Scripts/froala-editor/js/plugins/align.min.js",
                     "~/Scripts/froala-editor/js/plugins/entities.min.js",
                     "~/Scripts/froala-editor/js/plugins/char_counter.min.js",
                     "~/Scripts/froala-editor/js/plugins/link.min.js")); 

            // Added FontAwsome and Froala Editor css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-slate.css",
                      "~/Content/font-awesome.min.css",
                      "~/Scripts/froala-editor/css/froala_editor.min.css",
                      "~/Scripts/froala-editor/css/froala_style.css",
                      "~/Scripts/froala-editor/css/plugins/line_breaker.min.css",
                      "~/Scripts/froala-editor/css/plugins/emoticons.min.css",
                      "~/Scripts/froala-editor/css/plugins/code_view.min.css",
                      "~/Scripts/froala-editor/css/plugins/colors.min.css",
                      "~/Scripts/froala-editor/css/plugins/table.min.css",
                      "~/Scripts/froala-editor/css/plugins/char_counter.min.css",
                      "~/Content/site.css"));
        }
    }
}
