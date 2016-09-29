using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly int _pageSize;

        public ErrorLogger()
        {
            _pageSize = int.Parse(ConfigurationManager.AppSettings["ErrorLogPageSize"]);
        }

        public void LogError(Exception ex)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                LogErrorRecursive(context, ex);
                context.SaveChanges();
            }
        }

        public ErrorLog GetErrorLogPage(int pageNumber)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var errorLog = new ErrorLog();

                errorLog.CurrentPage = pageNumber;
                errorLog.TotalPages = GetPageCount(context);
                errorLog.Errors = context.Errors
                    .OrderByDescending(error => error.Id)
                    .Skip((pageNumber - 1) * _pageSize)
                    .Take(_pageSize).ToList();

                return errorLog;
            }
        }

        private void LogErrorRecursive(OfficeOlympicsDbEntities context, Exception ex)
        {
            var error = new Error();

            error.Type = ex.GetType().ToString();
            error.HResult = ex.HResult;
            error.Message = ex.Message;
            error.Source = ex.Source;
            error.StackTrace = ex.StackTrace;
            error.TimeStamp = DateTime.Now;

            context.Errors.Add(error);

            if (ex.InnerException != null)
            {
                LogErrorRecursive(context, ex.InnerException);
            }
        }

        private int GetPageCount(OfficeOlympicsDbEntities context)
        {
            int totalErrors = context.Errors.Count();

            return
                totalErrors % _pageSize == 0 ?
                totalErrors / _pageSize :
                totalErrors / _pageSize + 1;
        }
    }
}
