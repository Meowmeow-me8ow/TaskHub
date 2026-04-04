namespace Api.Middleware
{
    public class StudentInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public StudentInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Student-Name"] = "Tumashova Marina";
                context.Response.Headers["X-Student-Group"] = "RI-240912";
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
