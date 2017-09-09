using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Filters;
using ClcWorld.Utils.Exceptions;
using log4net;

namespace ClcWorld.WebApi.Attributes
{
    /// <summary>
    /// Catch all exceptions thrown during application execution
    /// </summary>
    public class HandleErrorAttribute: ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext context)
        {
            Log.Error(context.Exception.Message, context.Exception);

            if (context.Exception is BusinessException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Exception"
                });
            }

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}