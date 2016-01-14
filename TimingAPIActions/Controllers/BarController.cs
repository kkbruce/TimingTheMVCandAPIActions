using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TimingAPIActions.Controllers
{
    public class BarController : ApiController
    {
        public IHttpActionResult GetInActionTimer()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            System.Threading.Thread.Sleep(1527);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            System.Diagnostics.Debug.WriteLine($"ActionTimer: {ts.ToString()} from Bar/GetInActionTimer");

            return Ok($"ActionTimer: {ts.ToString()} from Bar/GetInActionTimer");
        }
    }
}
