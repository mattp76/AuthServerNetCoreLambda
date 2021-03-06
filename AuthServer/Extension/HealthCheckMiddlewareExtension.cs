﻿using AuthServer.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AuthServer.Extension
{
    public static class HealthCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder builder, string path)
        {
            return builder.UseMiddleware<HealthCheckMiddleware>(path);
        }
    }
}
