namespace CLINICAL.Api.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ValidationMiddleware>();
            return builder;
        }
    }
}
