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
                return RedirectToAction(nameof(Index), new { imageName = "no-image" });
            }

            var iconBytes = System.IO.File.ReadAllBytes(matchingIcon);

            return File(iconBytes, "image/png");
        }

        [HttpGet]
        public ActionResult Index(string imageName)
        {
            string sanitizedImageName = Path.GetFileName(imageName);
            string imageFullPath = Path.Combine(Server.MapPath("~/Content/Images"), $"{sanitizedImageName}.png");

            if (!System.IO.File.Exists(imageFullPath))
            {
                return RedirectToAction(nameof(Index), new { imageName = "no-image" });
            }

            var imageBytes = System.IO.File.ReadAllBytes(imageFullPath);

            return File(imageBytes, "image/png");
        }
    }
}