using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Exceptions;

public class EpNotFoundExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is EpNotFoundException)
        {
            var result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = 404
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }

        base.OnException(context);
    }
}
