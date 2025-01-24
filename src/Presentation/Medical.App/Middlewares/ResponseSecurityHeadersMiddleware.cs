namespace Medical.App.Middlewares
{
    public class ResponseSecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseSecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
            context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
            context.Response.Headers.Append("Referrer-Policy", "no-referrer-when-downgrade");
            context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");

            await _next(context);
        }
    }
}
