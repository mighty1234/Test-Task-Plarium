using App.Service.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.Data;
using AppService.Services;

namespace WebApiApp.Controllers
{
    public class LogController : ApiController
    {
        private ILogService logService = new LogService();

        public IEnumerable<Container> Get( int offset, int? limit)
        {
            return logService.GetLogs(offset, limit);
        }
        public IEnumerable<Container> GetContainers(DateTime start, DateTime end, int offset, int? limit)
        {
            return logService.getLogwithData(start, end, offset, limit);
        }
        public IEnumerable<LogaMountDesc> GetSorted(int n , DateTime start, DateTime end)
        {
            return logService.NRoutsDesc(n, start, end);

        }


    } 
}
