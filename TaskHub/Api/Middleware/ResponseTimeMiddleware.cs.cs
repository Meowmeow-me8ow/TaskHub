using System.Diagnostics;

namespace Api.Middleware
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                context.Response.Headers["X-Response-Time-Ms"] = stopwatch.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
