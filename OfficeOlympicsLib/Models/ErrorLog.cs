using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Models
{
    public class ErrorLog
    {
        public IEnumerable<Error> Errors { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
