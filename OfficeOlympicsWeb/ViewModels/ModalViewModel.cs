using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class ModalViewModel
    {
        public string HtmlId { get; set; }
        public string Title { get; set; }
        public string ContentAction { get; set; }
        public string ContentController { get; set; }
        public object ContentRouteValues { get; set; }
    }
}