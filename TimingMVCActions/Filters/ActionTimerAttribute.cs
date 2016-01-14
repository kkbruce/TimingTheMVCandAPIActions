using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimingMVCActions.Filters
{
    public class ActionTimerAttribute : ActionFilterAttribute
    {
        private Stopwatch swAction;
        private Stopwatch swView;

        public ActionTimerAttribute()
        {
            swAction = new Stopwatch();
            swView = new Stopwatch();
        }

        #region 計算 Action 執行時間

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            swAction.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            swAction.Stop();
            TimeSpan ts = swAction.Elapsed;
            swAction.Reset();
            Debug.WriteLine($"ActionTimer: {ts.ToString()} from {controllerName}/{actionName}");

            // 輸出至 client header
            var httpContext = filterContext.HttpContext;
            var response = httpContext.Response;
            response.AddHeader("X-Stopwatch", ts.ToString());

            base.OnActionExecuted(filterContext);
        }
        #endregion

        #region 計算 View 執行時間

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            swView.Start();
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            swView.Stop();
            TimeSpan ts = swView.Elapsed;
            swView.Reset();
            Debug.WriteLine($"ViewTimer: {ts.ToString()} from {controllerName}/{actionName}");
            base.OnResultExecuted(filterContext);
        }

        #endregion
    }
}