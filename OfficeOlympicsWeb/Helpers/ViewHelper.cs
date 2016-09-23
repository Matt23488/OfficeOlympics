using OfficeOlympicsWeb.Controllers;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OfficeOlympicsWeb.Helpers
{
    public static class ViewHelper
    {
        //public static string RenderPartialToString(string view, object model, ControllerContext context)
        //{
        //    if (string.IsNullOrEmpty(view))
        //    {
        //        view = context.RouteData.GetRequiredString("action");
        //    }

        //    var viewData = new ViewDataDictionary();
        //    var tempData = new TempDataDictionary();

        //    viewData.Model = model;

        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(context, view);
        //        var viewContext = new ViewContext(context, viewResult.View, viewData, tempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}

        //public static string PartialView(string view, object model)
        //{
        //    var controller = new HomeController(null, null);
        //    //controller.ControllerContext = new ControllerContext(HttpContext.Current, new RouteData(), controller);
        //    return RenderPartialToString(view, model, new ControllerContext(controller.Request.RequestContext, controller));
        //}

        public static string PartialView<TModel>(string view, TModel model)
        {
            try
            {
                var template = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"Views\Shared\{view}.cshtml"));
                return Engine.Razor.RunCompile(template, "templateKey", typeof(TModel), model);
            }
            catch(TemplateCompilationException ex)
            {
                throw;
            }
        }
    }
}