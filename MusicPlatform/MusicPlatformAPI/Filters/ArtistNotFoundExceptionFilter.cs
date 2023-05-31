using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Exceptions;

namespace MusicPlatformAPI.Filters
{
    public class ArtistNotFoundExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArtistNotFoundException)
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
}
