using App.Data;
using AppService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;



namespace App.Service.Services
{

    public class LogService : ILogService
    {
       public  IEnumerable<Container> logs;
        private LOGFilesEntities db = new LOGFilesEntities();

        public Container GetLog(int id)
        {
            throw new NotImplementedException();
        }
      
        public List<Container> GetLogs( int offset, int? limit)
        {

            

            //if (start != null && end != null)
            //{
            //    logs = db.Containers.Where(x => x.ID > offset && (x.RequestTime <= end && x.RequestTime >= start))
            //          .OrderBy(x => x.RequestTime)
            //          .Take(limit.Value);
            //}
            //else
            //{
            //    logs = db.Containers.Where(x => x.ID > offset)
            //          .OrderBy(x => x.RequestTime)
            //          .Take(limit.Value);
            //}

             logs = db.Containers.Where(x => x.ID > offset)
                        .OrderBy(x => x.RequestTime)
                        .Take(limit.Value);

            return logs.ToList();
            //  return db.Containers.ToList();
        }

        public List<Container> getLogwithData(DateTime start, DateTime end, int offset, int? limit)
        {
            logs = db.Containers.Where(x => x.ID > offset && (x.RequestTime <= end && x.RequestTime >= start))
                      .OrderBy(x => x.RequestTime)
                      .Take(limit.Value);
            return logs.ToList();
        }


        //routing api/Log/{2}/{}/{
        public List<LogaMountDesc> NRoutsDesc(int n, DateTime start, DateTime end)
        {
            IQueryable<LogaMountDesc> returnvalue;
            if (start == DateTime.MinValue || end == DateTime.MaxValue)
            {
               
                returnvalue = db.Containers/*.Where(x => x.RequestTime > start && x.RequestTime < end)*/
                    .GroupBy(x => x.Routing)
                    .Select(group => new LogaMountDesc
                    {
                        Routing = group.Key,
                        Amount = group.Count()
                    }
                    ).Take(n).OrderBy(x => x.Amount);

                return returnvalue.ToList();
            }
            else
            {
                returnvalue = db.Containers.Where(x => x.RequestTime > start && x.RequestTime < end)
                  .GroupBy(x => x.Routing)
                  .Select(group => new LogaMountDesc
                    {
                        Routing = group.Key,
                        Amount = group.Count()
                    }
                    ).Take(n).OrderBy(x => x.Amount);

                return returnvalue.ToList();
            }
           
        }
        public List<LogaMountDesc> NHostsDesc(int n, DateTime start, DateTime end)
        {
            IQueryable<LogaMountDesc> returnvalue;
            if (start == DateTime.MinValue || end == DateTime.MaxValue)
            {

                returnvalue = db.Containers/*.Where(x => x.RequestTime > start && x.RequestTime < end)*/
                    .GroupBy(x => x.IpOrHost)
                    .Select(group => new LogaMountDesc
                    {
                        Routing = group.Key,
                        Amount = group.Count()
                    }
                    ).Take(n).OrderBy(x => x.Amount);

                return returnvalue.ToList();
            }
            else
            {
                returnvalue = db.Containers.Where(x => x.RequestTime > start && x.RequestTime < end)
                  .GroupBy(x => x.IpOrHost)
                  .Select(group => new LogaMountDesc
                  {
                      Routing = group.Key,
                      Amount = group.Count()
                  }
                    ).Take(n).OrderBy(x => x.Amount);
                return returnvalue.ToList();
            }

       
    }

}
}