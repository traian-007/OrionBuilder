using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Orion.API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is null)
            {
                return;
            }

            var exception = context.Exception;

            context.Result = new ObjectResult(new { error = "An error occurred while processing your request. " })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
