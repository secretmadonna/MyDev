using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyDev.Api.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public override void Init()
        {
            System.Console.WriteLine();
        }

        #region BeginRequest->EndRequest，根据Module的注册顺序执行，最后执行HttpApplication中的事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_BeginRequest(object sender, EventArgs e)
        {
        }
        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }
        private void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
        }
        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
        }
        private void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {
        }
        private void Application_ResolveRequestCache(object sender, EventArgs e)
        {
        }
        private void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
        }
        private void Application_MapRequestHandler(object sender, EventArgs e)
        {
        }
        private void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
        }
        private void Application_AcquireRequestState(object sender, EventArgs e)
        {
        }
        private void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
        }
        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
        }

        //

        private void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
        }
        private void Application_ReleaseRequestState(object sender, EventArgs e)
        {
        }
        private void Application_PostReleaseRequestState(object sender, EventArgs e)
        {
        }
        private void Application_UpdateRequestCache(object sender, EventArgs e)
        {
        }
        private void Application_PostUpdateRequestCache(object sender, EventArgs e)
        {
        }
        private void Application_LogRequest(object sender, EventArgs e)
        {
        }
        private void Application_PostLogRequest(object sender, EventArgs e)
        {
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
        }

        #endregion

        #region Application中，PreSendRequestContent->PreSendRequestHeaders，且先于Module执行

        private void Application_PreSendRequestContent(object sender, EventArgs e)
        {
        }
        private void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
        }

        #endregion

        private void Application_RequestCompleted(object sender, EventArgs e)
        {
        }


        public override void Dispose()
        {
        }
        /// <summary>
        /// 事件，被调用的方式，应该和BeginRequest是相同的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Disposed(object sender, EventArgs e)
        {
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 事件，被调用的方式，应该和BeginRequest是相同的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Error(object sender, EventArgs e)
        {
        }

        public void Session_Start(object sender, EventArgs e)
        {
        }
        public void Session_End(object sender, EventArgs e)
        {
        }
    }
}
