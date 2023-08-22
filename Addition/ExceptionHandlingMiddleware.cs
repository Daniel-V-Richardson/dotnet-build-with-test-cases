using Sentry;
using System.Diagnostics;

namespace Jenkins_build
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                Debug.WriteLine($"Exception caught and captured: {ex.Message}");
            }
        }
    }
}
