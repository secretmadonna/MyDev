using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDev.UserInterface.WebSite.Portal.Web.Controllers
{
    public class TestAjaxController : Controller
    {
        private static readonly string _absoluteDir = AppDomain.CurrentDomain.BaseDirectory;
        // GET: TestAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetGetJson()
        {
            var obj = new { StatusCode = 100, StatusDescription = "OK", ReturnData = "哈哈GET" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPostJson()
        {
            var obj = new { StatusCode = 100, StatusDescription = "OK", ReturnData = "哈哈POST" };
            return Json(obj);
        }

        [HttpPost]
        public JsonResult SaveFormData()
        {
            var request = Request;

            Dictionary<string, string> fileDic = new Dictionary<string, string>();
            var files = request.Files;
            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var name = files.GetKey(i);
                    var file = files[i];
                    var fileSavePath = System.IO.Path.Combine(_absoluteDir, @"Content\Resource\", file.FileName);
                    var dir = System.IO.Path.GetDirectoryName(fileSavePath);
                    if (!System.IO.Directory.Exists(dir))
                    {
                        System.IO.Directory.CreateDirectory(dir);
                    }
                    file.SaveAs(fileSavePath);
                    fileDic.Add(name, fileSavePath);
                }
            }

            var obj = new
            {
                StatusCode = 100,
                StatusDescription = "OK",
                ReturnData = fileDic
            };
            return Json(obj);
        }

        [HttpPost]
        public ActionResult GetTextJson()
        {
            var obj = new
            {
                StatusCode = 100,
                StatusDescription = "OK",
                ReturnData = new
                {
                    Request.AcceptTypes,
                    Request.AnonymousID,
                    Request.ApplicationPath,
                    Request.AppRelativeCurrentExecutionFilePath,
                    Request.ClientCertificate,
                    Request.ContentEncoding,
                    Request.ContentLength,
                    Request.ContentType,
                    Request.Cookies,
                    Request.CurrentExecutionFilePath,
                    Request.CurrentExecutionFilePathExtension,
                    Request.FilePath,
                    Request.Files,
                    Request.Form,
                    Request.Headers,
                    Request.HttpChannelBinding,
                    Request.HttpMethod,
                    Request.IsAuthenticated,
                    Request.IsLocal,
                    Request.IsSecureConnection,
                    Request.Params,
                    Request.Path,
                    Request.PathInfo,
                    Request.PhysicalApplicationPath,
                    Request.PhysicalPath,
                    Request.QueryString,
                    Request.RawUrl,
                    Request.ReadEntityBodyMode,
                    Request.RequestType,
                    Request.ServerVariables,
                    Request.TimedOutToken,
                    Request.TotalBytes,
                    Request.Unvalidated,
                    Request.Url,
                    Request.UrlReferrer,
                    Request.UserAgent,
                    Request.UserHostAddress,
                    Request.UserHostName,
                    Request.UserLanguages,

                    Browser = new
                    {
                        Request.Browser.ActiveXControls,
                        Request.Browser.Adapters,
                        Request.Browser.AOL,
                        Request.Browser.BackgroundSounds,
                        Request.Browser.Beta,
                        Request.Browser.Browser,
                        Request.Browser.Browsers,
                        Request.Browser.CanCombineFormsInDeck,
                        Request.Browser.CanInitiateVoiceCall,
                        Request.Browser.CanRenderAfterInputOrSelectElement,
                        Request.Browser.CanRenderEmptySelects,
                        Request.Browser.CanRenderInputAndSelectElementsTogether,
                        Request.Browser.CanRenderMixedSelects,
                        Request.Browser.CanRenderOneventAndPrevElementsTogether,
                        Request.Browser.CanRenderPostBackCards,
                        Request.Browser.CanRenderSetvarZeroWithMultiSelectionList,
                        Request.Browser.CanSendMail,
                        Request.Browser.Capabilities,
                        Request.Browser.CDF,
                        Request.Browser.ClrVersion,
                        Request.Browser.Cookies,
                        Request.Browser.Crawler,
                        Request.Browser.DefaultSubmitButtonLimit,
                        Request.Browser.EcmaScriptVersion,
                        Request.Browser.Frames,
                        Request.Browser.GatewayMajorVersion,
                        Request.Browser.GatewayMinorVersion,
                        Request.Browser.GatewayVersion,
                        Request.Browser.HasBackButton,
                        Request.Browser.HidesRightAlignedMultiselectScrollbars,
                        Request.Browser.HtmlTextWriter,
                        Request.Browser.Id,
                        Request.Browser.InputType,
                        Request.Browser.IsColor,
                        Request.Browser.IsMobileDevice,
                        Request.Browser.JavaApplets,
                        Request.Browser.JScriptVersion,
                        Request.Browser.MajorVersion,
                        Request.Browser.MaximumHrefLength,
                        Request.Browser.MaximumRenderedPageSize,
                        Request.Browser.MaximumSoftkeyLabelLength,
                        Request.Browser.MinorVersion,
                        Request.Browser.MinorVersionString,
                        Request.Browser.MobileDeviceManufacturer,
                        Request.Browser.MobileDeviceModel,
                        Request.Browser.MSDomVersion,
                        Request.Browser.NumberOfSoftkeys,
                        Request.Browser.Platform,
                        Request.Browser.PreferredImageMime,
                        Request.Browser.PreferredRenderingMime,
                        Request.Browser.PreferredRenderingType,
                        Request.Browser.PreferredRequestEncoding,
                        Request.Browser.PreferredResponseEncoding,
                        Request.Browser.RendersBreakBeforeWmlSelectAndInput,
                        Request.Browser.RendersBreaksAfterHtmlLists,
                        Request.Browser.RendersBreaksAfterWmlAnchor,
                        Request.Browser.RendersBreaksAfterWmlInput,
                        Request.Browser.RendersWmlDoAcceptsInline,
                        Request.Browser.RendersWmlSelectsAsMenuCards,
                        Request.Browser.RequiredMetaTagNameValue,
                        Request.Browser.RequiresAttributeColonSubstitution,
                        Request.Browser.RequiresContentTypeMetaTag,
                        Request.Browser.RequiresControlStateInSession,
                        Request.Browser.RequiresDBCSCharacter,
                        Request.Browser.RequiresHtmlAdaptiveErrorReporting,
                        Request.Browser.RequiresLeadingPageBreak,
                        Request.Browser.RequiresNoBreakInFormatting,
                        Request.Browser.RequiresOutputOptimization,
                        Request.Browser.RequiresPhoneNumbersAsPlainText,
                        Request.Browser.RequiresSpecialViewStateEncoding,
                        Request.Browser.RequiresUniqueFilePathSuffix,
                        Request.Browser.RequiresUniqueHtmlCheckboxNames,
                        Request.Browser.RequiresUniqueHtmlInputNames,
                        Request.Browser.RequiresUrlEncodedPostfieldValues,
                        Request.Browser.ScreenBitDepth,
                        Request.Browser.ScreenCharactersHeight,
                        Request.Browser.ScreenCharactersWidth,
                        Request.Browser.ScreenPixelsHeight,
                        Request.Browser.ScreenPixelsWidth,
                        Request.Browser.SupportsAccesskeyAttribute,
                        Request.Browser.SupportsBodyColor,
                        Request.Browser.SupportsBold,
                        Request.Browser.SupportsCacheControlMetaTag,
                        Request.Browser.SupportsCallback,
                        Request.Browser.SupportsCss,
                        Request.Browser.SupportsDivAlign,
                        Request.Browser.SupportsDivNoWrap,
                        Request.Browser.SupportsEmptyStringInCookieValue,
                        Request.Browser.SupportsFontColor,
                        Request.Browser.SupportsFontName,
                        Request.Browser.SupportsFontSize,
                        Request.Browser.SupportsImageSubmit,
                        Request.Browser.SupportsIModeSymbols,
                        Request.Browser.SupportsInputIStyle,
                        Request.Browser.SupportsInputMode,
                        Request.Browser.SupportsItalic,
                        Request.Browser.SupportsJPhoneMultiMediaAttributes,
                        Request.Browser.SupportsJPhoneSymbols,
                        Request.Browser.SupportsQueryStringInFormAction,
                        Request.Browser.SupportsRedirectWithCookie,
                        Request.Browser.SupportsSelectMultiple,
                        Request.Browser.SupportsUncheck,
                        Request.Browser.SupportsXmlHttp,
                        Request.Browser.Tables,
                        Request.Browser.Type,
                        Request.Browser.UseOptimizedCacheKey,
                        Request.Browser.VBScript,
                        Request.Browser.Version,
                        Request.Browser.W3CDomVersion,
                        Request.Browser.Win16,
                        Request.Browser.Win32

                        //TagWriter = Request.Browser.TagWriter
                    },
                    Filter = new
                    {
                        Request.Filter.CanRead,
                        Request.Filter.CanSeek,
                        Request.Filter.CanTimeout,
                        Request.Filter.CanWrite,
                        Request.Filter.Length,
                        Request.Filter.Position

                        //Request.Filter.ReadTimeout,
                        //Request.Filter.WriteTimeout
                    },
                    LogonUserIdentity = new
                    {
                        Request.LogonUserIdentity.AuthenticationType,
                        Request.LogonUserIdentity.BootstrapContext,
                        Request.LogonUserIdentity.Groups,
                        Request.LogonUserIdentity.ImpersonationLevel,
                        Request.LogonUserIdentity.IsAnonymous,
                        Request.LogonUserIdentity.IsAuthenticated,
                        Request.LogonUserIdentity.IsGuest,
                        Request.LogonUserIdentity.IsSystem,
                        Request.LogonUserIdentity.Label,
                        Request.LogonUserIdentity.Name,
                        Request.LogonUserIdentity.NameClaimType,
                        Request.LogonUserIdentity.Owner,
                        Request.LogonUserIdentity.RoleClaimType,
                        Request.LogonUserIdentity.Token,
                        Request.LogonUserIdentity.User

                        //Request.LogonUserIdentity.Actor,
                        //Request.LogonUserIdentity.Claims,
                        //Request.LogonUserIdentity.DeviceClaims,
                        //Request.LogonUserIdentity.UserClaims
                    },
                    RequestContext = new
                    {
                        HttpContext = new
                        {
                            Request.RequestContext.HttpContext.AllErrors,
                            Request.RequestContext.HttpContext.AllowAsyncDuringSyncStages,
                            Request.RequestContext.HttpContext.AsyncPreloadMode,
                            Request.RequestContext.HttpContext.Cache,
                            Request.RequestContext.HttpContext.CurrentNotification,
                            Request.RequestContext.HttpContext.Error,
                            Request.RequestContext.HttpContext.IsCustomErrorEnabled,
                            Request.RequestContext.HttpContext.IsDebuggingEnabled,
                            Request.RequestContext.HttpContext.IsPostNotification,
                            Request.RequestContext.HttpContext.IsWebSocketRequest,
                            Request.RequestContext.HttpContext.IsWebSocketRequestUpgrading,
                            Request.RequestContext.HttpContext.PageInstrumentation,
                            Request.RequestContext.HttpContext.Server,
                            Request.RequestContext.HttpContext.Session,
                            Request.RequestContext.HttpContext.SkipAuthorization,
                            Request.RequestContext.HttpContext.ThreadAbortOnTimeout,
                            Request.RequestContext.HttpContext.Timestamp,
                            Request.RequestContext.HttpContext.Trace,
                            Request.RequestContext.HttpContext.WebSocketNegotiatedProtocol,
                            Request.RequestContext.HttpContext.WebSocketRequestedProtocols

                            //Request.RequestContext.HttpContext.Application,
                            //Request.RequestContext.HttpContext.ApplicationInstance,
                            //Request.RequestContext.HttpContext.CurrentHandler,
                            //Request.RequestContext.HttpContext.Handler,
                            //Request.RequestContext.HttpContext.Items,
                            //Request.RequestContext.HttpContext.PreviousHandler,
                            //Request.RequestContext.HttpContext.Profile,
                            //Request.RequestContext.HttpContext.Request,
                            //Request.RequestContext.HttpContext.Response,
                            //Request.RequestContext.HttpContext.User,
                        },
                        Request.RequestContext.RouteData
                    }

                    //InputStream = Request.InputStream
                }
            };
            return Json(obj);
            //return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetImage()
        {
            return Content("this is a test.");
        }



        //ContentResult
        //EmptyResult
        //FileResult : FileContentResult/FilePathResult/FileStreamResult
        //HttpStatusCodeResult : HttpNotFoundResult/HttpUnauthorizedResult
        //JsonResult
        //JavaScriptResult
        //RedirectResult
        //RedirectToRouteResult
        //ViewResultBase : ViewResult/PartialViewResult

        //ModelValidationResult
        //ValueProviderResult
        //ViewEngineResult
        public ActionResult GetResult()
        {
            //return Content("hahahahahaha");
            //return new EmptyResult();
            return File(System.IO.Path.Combine(_absoluteDir, @"Content\Resource\", "QQ20160420182637.png"), "image/png");
            //return HttpNotFound();
            //return new HttpUnauthorizedResult();
            //return Json(new { a = "haha", b = 1, c = DateTime.Now }, JsonRequestBehavior.AllowGet);
            //return JavaScript("alert(\"OK\")");
            //return Redirect("/TestAjax/GetImage");
            //return RedirectToAction("GetImage");
            //return View("Index");
        }
    }
}