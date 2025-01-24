namespace Medical.App.Middlewares
{
    public class ESLocalizationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var culture = new System.Globalization.CultureInfo("es-PE");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            await next(context);
        }
    }
}
