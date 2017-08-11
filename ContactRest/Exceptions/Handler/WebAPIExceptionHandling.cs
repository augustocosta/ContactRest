using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Facebook;

namespace ContactRest.Exceptions.Handler
{
    public class WebApiExceptionHandling : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is FacebookOAuthException || context.Exception is ContactRestAuthException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.Forbidden, context.Exception.Message);
            }
            else
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            }
        }
    }
}