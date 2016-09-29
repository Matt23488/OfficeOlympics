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

        public async Task LogErrorAsync(Exception ex)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                await LogErrorRecursiveAsync(context, ex);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ErrorLog> GetErrorLogPageAsync(int pageNumber)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var errorLog = new ErrorLog();

                errorLog.CurrentPage = pageNumber;
                errorLog.TotalPages = await GetPageCount(context);
                errorLog.Errors = context.Errors
                    .OrderByDescending(error => error.Id)
                    .Skip((pageNumber - 1) * _pageSize)
                    .Take(_pageSize).ToList();

                return errorLog;
            }
        }

        private async Task LogErrorRecursiveAsync(OfficeOlympicsDbEntities context, Exception ex)
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
                await LogErrorRecursiveAsync(context, ex.InnerException);
            }
        }

        private async Task<int> GetPageCount(OfficeOlympicsDbEntities context)
        {
            return await Task.Run(() =>
            {
                int totalErrors = context.Errors.Count();

                return
                    totalErrors % _pageSize == 0 ?
                    totalErrors / _pageSize :
                    totalErrors / _pageSize + 1;
            });
        }
    }
}
