using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OfficeOlympicsWeb
{
    public static class RazorEngineConfig
    {
        public static void RegisterRazorEngine()
        {
            // RazorEngine
            var config = new TemplateServiceConfiguration();

            config.Debug = true;

            foreach (string s in GetViewNamespaces())
            {
                config.Namespaces.Add(s);
            }

            var service = RazorEngineService.Create(config);
            Engine.Razor = service;
        }

        private static IEnumerable<string> GetViewNamespaces()
        {
            var viewConfig = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Views\Web.config"));

            return viewConfig.Root
                .Descendants().Single(node => node.Name == "system.web.webPages.razor")
                .Descendants().Single(node => node.Name == "pages")
                .Descendants().Single(node => node.Name == "namespaces")
                .Descendants().Where(node => node.Name == "add")
                .Select(node => node.Attribute("namespace").Value);
        }
    }
}