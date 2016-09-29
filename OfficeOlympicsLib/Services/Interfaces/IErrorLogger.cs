using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services.Interfaces
{
    public interface IErrorLogger
    {
        void LogError(Exception ex);
        ErrorLog GetErrorLogPage(int pageNumber);
    }
}
