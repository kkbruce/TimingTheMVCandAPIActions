using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimingMVCActions.Controllers
{
    public class FooController : Controller
    {
        // GET: Foo
        public ActionResult InActionTimer()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            // 模擬程式執行
            System.Threading.Thread.Sleep(1527);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            System.Diagnostics.Debug.WriteLine($"ActionTimer: {ts.ToString()} from Foo/InActionTimer");

            return Content($"ActionTimer: {ts.ToString()} from Foo/InActionTimer");
        }

        public ActionResult InActionTimer1()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            // 模擬程式執行                                                                                
            System.Threading.Thread.Sleep(1527);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            System.Diagnostics.Debug.WriteLine($"ActionTimer: {ts.ToString()} from Foo/InActionTimer1");

            return Content($"ActionTimer: {ts.ToString()} from Foo/InActionTimer1");
        }

        public ActionResult InActionTimer2()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            // 模擬程式執行                                                                                
            System.Threading.Thread.Sleep(1527);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            System.Diagnostics.Debug.WriteLine($"ActionTimer: {ts.ToString()} from Foo/InActionTimer2");

            return Content($"ActionTimer: {ts.ToString()} from Foo/InActionTimer2");
        }
    }
}