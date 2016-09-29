using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult GetIcon(string fileGuid)
        {
            var iconDirectory = new DirectoryInfo(ConfigurationManager.AppSettings["IconSaveLocation"]);
            string matchingIcon = iconDirectory.GetFiles().SingleOrDefault(obj => obj.Name.Contains(fileGuid))?.FullName;

            if (string.IsNullOrEmpty(matchingIcon))
            {
                matchingIcon = Server.MapPath("~/Content/Images/no-image.png");
            }

            var iconBytes = System.IO.File.ReadAllBytes(matchingIcon);

            return File(iconBytes, "image/png");
        }
    }
}