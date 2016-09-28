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
        public async Task<ActionResult> GetIcon(string fileGuid)
        {
            var iconDirectory = new DirectoryInfo(ConfigurationManager.AppSettings["IconSaveLocation"]);
            string matchingIcon = iconDirectory.GetFiles().Single(obj => obj.Name.Contains(fileGuid)).FullName;
            var iconBytes = System.IO.File.ReadAllBytes(matchingIcon);

            return File(iconBytes, "image/png");
        }
    }
}