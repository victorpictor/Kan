using System.Web.Http.Filters;

namespace Kan.Api.Response
{
    public class HandleError : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                actionExecutedContext.Response = new HttpResponses().Create(actionExecutedContext.Request, actionExecutedContext.Exception);
        }
    }
}