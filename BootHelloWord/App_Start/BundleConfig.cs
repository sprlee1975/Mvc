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
            "~/scripts/bootstrap*",
            "~/scripts/jquery-1.9.1.js",
            "~/scripts/jquery.unobtrusive*",
            "~/scripts/jquery.validate*",            
            "~/scripts/site.js"));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css",
            "~/Content/signin.css"));
        }
    }
}