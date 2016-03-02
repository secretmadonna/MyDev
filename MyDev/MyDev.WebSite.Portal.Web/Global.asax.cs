using MyDev.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDev.WebSite.Portal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly string logger = @"d:\app.txt";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Start\r\n");
        }

        #region BeginRequest->EndRequest，根据Module的注册顺序执行，最后执行HttpApplication中的事件
        
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_BeginRequest\r\n");
        }
        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AuthenticateRequest\r\n");
        }
        private void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAuthenticateRequest\r\n");
        }
        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AuthorizeRequest\r\n");
        }
        private void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAuthorizeRequest\r\n");
        }
        private void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_ResolveRequestCache\r\n");
        }
        private void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostResolveRequestCache\r\n");
        }
        private void Application_MapRequestHandler(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_MapRequestHandler\r\n");
        }
        private void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostMapRequestHandler\r\n");
        }
        private void Application_AcquireRequestState(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_AcquireRequestState\r\n");
        }
        private void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostAcquireRequestState\r\n");
        }
        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreRequestHandlerExecute\r\n");
        }

        //

        private void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostRequestHandlerExecute\r\n");
        }
        private void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_ReleaseRequestState\r\n");
        }
        private void Application_PostReleaseRequestState(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostReleaseRequestState\r\n");
        }
        private void Application_UpdateRequestCache(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_UpdateRequestCache\r\n");
        }
        private void Application_PostUpdateRequestCache(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostUpdateRequestCache\r\n");
        }
        private void Application_LogRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_LogRequest\r\n");
        }
        private void Application_PostLogRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PostLogRequest\r\n");
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_EndRequest\r\n");
        }

        #endregion

        #region Application中，PreSendRequestContent->PreSendRequestHeaders，且先于Module执行

        private void Application_PreSendRequestContent(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreSendRequestContent\r\n");
        }
        private void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_PreSendRequestHeaders\r\n");
        }

        #endregion

        private void Application_RequestCompleted(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_RequestCompleted\r\n");
        }

        private void Application_Disposed(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Disposed\r\n");
        }
        
        private void Application_Error(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_Error\r\n");
        }

        public void Session_Start(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Session_Start\r\n");
        }
        public void Session_End(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Session_End\r\n");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Application_End\r\n");
        }



        #region Init/Dispose

        //public override void Init()
        //{
        //    LogHelper.Write(@"d:\app.txt", "info", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Init\r\n");
        //}
        //public override void Dispose()
        //{
        //    LogHelper.Write(@"d:\app.txt", "info", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Dispose\r\n");
        //}

        #endregion
    }
}
