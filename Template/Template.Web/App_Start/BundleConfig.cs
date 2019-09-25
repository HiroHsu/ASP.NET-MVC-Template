using System.Web;
using System.Web.Optimization;

namespace Template.Web
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vue")
                .Include("~/Scripts/babel.min.js")
                .Include("~/Scripts/polyfill.min.js")

                .Include("~/Scripts/vue.js")
                .Include("~/Scripts/ElementUI/element-ui.js")
                .Include("~/Scripts/axios.min.js")
                .Include("~/Scripts/httpVueLoader.js")

                );


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Normalize.css")
                .Include("~/Content/site.css")
                .Include("~/Content/ElementUI/element-ui.css")
                );
        }
    }
}
