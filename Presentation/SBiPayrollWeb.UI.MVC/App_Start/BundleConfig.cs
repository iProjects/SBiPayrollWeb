using System.Web;
using System.Web.Optimization;

namespace SBiPayrollWeb.UI.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/toast.js",
                        "~/Scripts/cookie_consent.js",
                        "~/Scripts/CustomScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-*"));

            bundles.Add(new ScriptBundle("~/bundles/MicrosoftAjax").Include(
                "~/Scripts/MicrosoftAjax.debug.js",
                "~/Scripts/MicrosoftAjax.js",
                "~/Scripts/MicrosoftMvcAjax.debug.js",
                "~/Scripts/MicrosoftMvcAjax.js",
                "~/Scripts/MicrosoftMvcValidation.debug.js",
                "~/Scripts/MicrosoftMvcValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/tablesorter").Include(
            "~/Scripts/jquery.tablesorter.js",
            "~/Scripts/jquery.tablesorter.min.js",
            "~/Scripts/jquery.tablesorter.pager.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
            "~/Scripts/jquery.dataTables.js",
            "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/CustomScripts").Include(
            "~/Scripts/CustomScripts.js",
            "~/Scripts/DatePickerReady.js",
            "~/Scripts/_references.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap-3.3.7.js"));

            bundles.Add(new ScriptBundle("~/bundles/toast").Include(
                        "~/Scripts/toast.js"));

            bundles.Add(new ScriptBundle("~/bundles/_AllScripts").Include("~/Scripts/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/employees_modern").Include(
                        "~/Scripts/employees_modern.js"));

            bundles.Add(new ScriptBundle("~/bundles/create_employee_modern").Include(
                        "~/Scripts/create_employee_modern.js"));

            bundles.Add(new ScriptBundle("~/bundles/employers_modern").Include(
                        "~/Scripts/employers_modern.js"));

            bundles.Add(new ScriptBundle("~/bundles/payroll_items_modern").Include(
                        "~/Scripts/payroll_items_modern.js"));

            bundles.Add(new ScriptBundle("~/bundles/indexdb").Include(
                        "~/Scripts/indexdb.js"));

            bundles.Add(new ScriptBundle("~/bundles/cookie_consent").Include(
                        "~/Scripts/cookie_consent.js"));

            bundles.Add(new ScriptBundle("~/bundles/edit_profile_modern").Include(
                        "~/Scripts/edit_profile_modern.js"));




            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/_AllStyles").Include("~/Content/*.css"));

            bundles.Add(new StyleBundle("~/bundles/modern_css").Include(
                "~/Content/jquery-ui-1.12.1.css",
                "~/Content/modern_layout.css",
                "~/Content/cookie_consent.css",
                "~/Content/toast.css"));

            bundles.Add(new StyleBundle("~/bundles/toast").Include(
                "~/Content/toast.css"));

            bundles.Add(new StyleBundle("~/bundles/employees_modern").Include(
                "~/Content/employees_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/employers_modern").Include(
                "~/Content/employers_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/auth_modern").Include(
                "~/Content/auth_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/edit_profile").Include(
                "~/Content/edit_profile.css"));

            bundles.Add(new StyleBundle("~/bundles/payroll_items_modern").Include(
                "~/Content/payroll_items_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/payrolls_modern").Include(
                "~/Content/payrolls_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/payrolls_modern").Include(
                "~/Content/edit_profile_modern.css"));

            bundles.Add(new StyleBundle("~/bundles/cookie_consent").Include(
                "~/Content/cookie_consent.css"));



#if !DEBUG
            { 
                BundleTable.EnableOptimizations = true;
            }
#endif

#if DEBUG
            //by default all minimized files are ignored in DEBUG mode. This will stop that.
            bundles.IgnoreList.Clear();
#endif

        }







    }
}