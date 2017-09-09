using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ClcWorld.WebApi.Attributes
{
    /// <summary>
    /// This filter allow overrides the response when a validation error ocurrs
    /// </summary>
    public class ValidateModelStateWebApiAttribute
        : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    actionContext.ModelState);
            }
        }
    }
}