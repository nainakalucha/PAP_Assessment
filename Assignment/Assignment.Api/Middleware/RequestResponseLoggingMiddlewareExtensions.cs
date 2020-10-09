using Microsoft.AspNetCore.Builder;

namespace Assignment.Api
{
    /// <summary>
    /// Extension of application builder for request response logging middleware.
    /// </summary>
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        /// <summary>
        /// Configure request response logging middleware
        /// </summary>
        /// <param name="builder">Application builder.</param>
        /// <returns>Returns application builder.</returns>
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
