namespace Api.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder bıilder)
        {
            return bıilder.UseMiddleware<ValidaitonMiddleware>();
        }
    }
}
