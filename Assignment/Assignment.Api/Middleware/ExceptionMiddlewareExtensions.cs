using Microsoft.AspNetCore.Builder;

namespace Assignment.Api
{
    /// <summary>
    /// Extension of application builder for exception middleware.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Configure exception middleware.
        /// </summary>
        /// <param name="app">Application builder.</param>
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
