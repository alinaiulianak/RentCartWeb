﻿using System.Web;
using System.Web.Optimization;

namespace RentCartWeb.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.ui").Include(
                       "~/Scripts/datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

        //    bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
        //"~/Content/themes/base/jquery.ui.core.css",
        //"~/Content/themes/base/jquery.ui.datepicker.css",
        //"~/Content/themes/base/jquery.ui.theme.css"));

        //    bundles.Add(new ScriptBundle("~/bundles/datePicker").Include(
        //  "~/Scripts/moment.min.js",
        //  "~/Scripts/bootstrap-datetimepicker.min.js"));

        //    bundles.Add(new StyleBundle("~/Content/datepicker").Include(
        //             "~/Content/bootstrap-datetimepicker.min.css"));

        }
    }
}
