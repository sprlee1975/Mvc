using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BootHelloWord
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
            "~/scripts/jquery*",
            "~/scripts/bootstrap*",
            //"~/scripts/jquery.unobtrusive*",
            //"~/scripts/jquery.validate*",
            "~/scripts/superfish*",
            
            "~/scripts/site.js"));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css",
            "~/Content/superfish*",
            "~/Content/signin.css"));
        }
    }
}