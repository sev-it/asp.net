using System.Web;
using System.Web.Optimization;

namespace ngNetMVC
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/site.css",
                       "~/Content/bootstrap.css",
                       "~/Content/bootstrap.min.css",
                       "~/Content/ui-bootstrap-csp.css"));

            bundles.Add(new ScriptBundle("~/bundles/ngNetMVC")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .Include("~/Scripts/ngNetMVC.js"));

            bundles.Add(new ScriptBundle("~/bundles/AngularJS")
                .Include("~/Scripts/AngularJS/angular.min.js",
                         "~/Scripts/AngularJS/angular-ui-router.min.js",
                         "~/Scripts/AngularJS/ui-bootstrap-tpls.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
