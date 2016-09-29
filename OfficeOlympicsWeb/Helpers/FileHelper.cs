using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OfficeOlympicsWeb.Helpers
{
    public static class FileHelper
    {
        public static IHtmlString FileUpload(this HtmlHelper html, string name, string accept = "")
        {
            var fileBuilder = new TagBuilder("input");
            fileBuilder.Attributes["type"] = "file";
            fileBuilder.Attributes["style"] = "display: none";
            fileBuilder.Attributes["name"] = name;
            if (!string.IsNullOrWhiteSpace(accept)) fileBuilder.Attributes["accept"] = accept;

            var labelBuilder = new TagBuilder("label");
            labelBuilder.Attributes["class"] = "btn btn-info btn-file";
            labelBuilder.InnerHtml = $"Browse {fileBuilder.ToString(TagRenderMode.SelfClosing)}";

            var fileNameBuilder = new TagBuilder("span");
            fileNameBuilder.Attributes["class"] = "file-name";

            var containerBuilder = new TagBuilder("span");
            containerBuilder.Attributes["class"] = "file-upload";
            containerBuilder.InnerHtml = $"{labelBuilder.ToString()}{fileNameBuilder.ToString()}";

            return MvcHtmlString.Create(containerBuilder.ToString());
        }

        public static IHtmlString FileUploadFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, HttpPostedFileBase>> expression, string accept = "")
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            return FileUpload(html, name, accept);
        }

        public static IHtmlString Icon(this HtmlHelper html, string fileName, IconSize size = IconSize.Default)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);

            var builder = new TagBuilder("img");

            builder.Attributes["class"] = GetIconSizeClass(size);
            builder.Attributes["src"] = url.Action("GetIcon", "Image", new { fileGuid = Path.GetFileNameWithoutExtension(fileName) });

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString IconFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, string>> expression, IconSize size = IconSize.Default)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string iconFileName = metadata.Model as string;
            return Icon(html, iconFileName, size);
        }

        private static string GetIconSizeClass(IconSize size)
        {
            switch (size)
            {
                case IconSize.Small: return "event-icon-small";
                case IconSize.Medium:
                default: return "event-icon";
            }
        }
    }
}