using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicPlatform.Business.Exceptions;

namespace MusicPlatformAPI.Filters
{
    public class AlbumNotFoundExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is AlbumNotFoundException)
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
