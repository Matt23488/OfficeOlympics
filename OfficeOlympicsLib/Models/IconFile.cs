using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Models
{
    public class IconFile
    {
        public string UploadedFileName { get; set; }
        public byte[] Bytes { get; set; }
    }
}
