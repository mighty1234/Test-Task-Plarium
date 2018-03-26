using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using AppService.Services;

namespace App.Service.Services
{
  public  interface ILogService
    {
        List<LogaMountDesc> NRoutsDesc(int n, DateTime start, DateTime end);
        List<LogaMountDesc> NHostsDesc(int n, DateTime start, DateTime end);
        List<Container> getLogwithData(DateTime start, DateTime end, int offset, int? limit);
        List<Container> GetLogs( int offset, int? limit);
        Container GetLog(int id);
    }
}
