﻿using System.Web;
using System.Web.Optimization;

namespace ControleCustos
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

            bundles.Add(new ScriptBundle("~/bundles/lista-projetos").Include(
                        "~/Scripts/app/projeto/lista.js"));

            bundles.Add(new ScriptBundle("~/bundles/projeto-recursos-lista").Include(
                        "~/Scripts/app/projetos-recursos/lista-projetos-recursos.js"));

            bundles.Add(new ScriptBundle("~/bundles/recurso").Include(
                      "~/Scripts/app/projeto/recurso.js"));

            bundles.Add(new ScriptBundle("~/bundles/relatorio").Include(
                      "~/Scripts/app/relatorio/relatorios.js",
                      "~/Scripts/app/relatorio/grafico.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/loaders.css"));
        }
    }
}
