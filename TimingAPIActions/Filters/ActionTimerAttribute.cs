using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TimingAPIActions.Filters
{
    public class ActionTimerAttribute : ActionFilterAttribute
    {
        private Stopwatch sw;
        public ActionTimerAttribute()
        {
            sw = new Stopwatch();
        }

        #region 計算 API Action 執行時間

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            sw.Start();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            sw.Reset();
            Debug.WriteLine($"ActionTimer: {ts.ToString()} from {controllerName}/{actionName}");
            base.OnActionExecuted(actionExecutedContext);
        }

        #endregion

    }
}