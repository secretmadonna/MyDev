using MyDev.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyDev.UserInterface.WebSite.Portal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Start.";
            LogHelper.Write(LogType.Web, info);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //StackExchange.Profiling
        }

        #region BeginRequest->EndRequest，根据Module的注册顺序执行，最后执行HttpApplication中的事件

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_BeginRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AuthenticateRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAuthenticateRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AuthorizeRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAuthorizeRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_ResolveRequestCache.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostResolveRequestCache.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_MapRequestHandler(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_MapRequestHandler.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostMapRequestHandler.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AcquireRequestState.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAcquireRequestState.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreRequestHandlerExecute.";
            LogHelper.Write(LogType.Web, info);
        }

        //

        private void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostRequestHandlerExecute.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_ReleaseRequestState.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostReleaseRequestState(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostReleaseRequestState.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_UpdateRequestCache(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_UpdateRequestCache.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostUpdateRequestCache(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostUpdateRequestCache.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_LogRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_LogRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PostLogRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostLogRequest.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_EndRequest.";
            LogHelper.Write(LogType.Web, info);
        }

        #endregion

        #region Application中，PreSendRequestContent->PreSendRequestHeaders，且先于Module执行

        private void Application_PreSendRequestContent(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreSendRequestContent.";
            LogHelper.Write(LogType.Web, info);
        }
        private void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreSendRequestHeaders.";
            LogHelper.Write(LogType.Web, info);
        }

        #endregion

        private void Application_RequestCompleted(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_RequestCompleted.";
            LogHelper.Write(LogType.Web, info);
        }

        private void Application_Disposed(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Disposed.";
            LogHelper.Write(LogType.Web, info);
        }

        private void Application_Error(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Error.";
            LogHelper.Write(LogType.Web, info);
        }

        public void Session_Start(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Session_Start.";
            LogHelper.Write(LogType.Web, info);
        }
        public void Session_End(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Session_End.";
            LogHelper.Write(LogType.Web, info);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_End.";
            LogHelper.Write(LogType.Web, info);
        }



        #region Init/Dispose

        //public override void Init()
        //{
        //    var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Init.";
        //    LogHelper.Write(LogType.Web, info);
        //}
        //public override void Dispose()
        //{
        //    var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Dispose.";
        //    LogHelper.Write(LogType.Web, info);
        //}

        #endregion
    }
}
