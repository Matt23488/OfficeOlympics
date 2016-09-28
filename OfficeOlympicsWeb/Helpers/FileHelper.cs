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
        public static IHtmlString FileUpload(this HtmlHelper html, string name, object htmlAttributes = null)
        {
            var innerFileBuilder = new TagBuilder("input");

            innerFileBuilder.Attributes["type"] = "file";
            innerFileBuilder.Attributes["style"] = "display: none;";
            innerFileBuilder.Attributes["name"] = name;

            foreach (var propertyInfo in htmlAttributes.GetType().GetProperties())
            {
                innerFileBuilder.Attributes[propertyInfo.Name] = propertyInfo.GetValue(htmlAttributes).ToString();
            }

            var outerLabelBuilder = new TagBuilder("label");

            outerLabelBuilder.Attributes["class"] = "btn btn-info btn-file";
            outerLabelBuilder.InnerHtml = $"Browse {innerFileBuilder.ToString(TagRenderMode.SelfClosing)}";

            return MvcHtmlString.Create(outerLabelBuilder.ToString());
        }

        public static IHtmlString FileUploadFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, HttpPostedFileBase>> expression, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            return FileUpload(html, name, htmlAttributes);
        }

        public static IHtmlString Icon(this HtmlHelper html, string fileName, IconSize size = IconSize.Default)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);

            var builder = new TagBuilder("img");

            builder.Attributes["class"] = GetIconSizeClass(size);
            //builder.Attributes["src"] = Path.Combine(ConfigurationManager.AppSettings["IconSaveLocation"], fileName);
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