using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Middleware
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class HealthCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _path;

        public HealthCheckMiddleware(RequestDelegate next, string path)
        {
            this._next = next;
            this._path = path;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == this._path)
            {
                context.Response.StatusCode = 200;
                context.Response.ContentLength = 2;
                await context.Response.WriteAsync("UP");
            }
            else
            {
                await this._next(context);
            }
        }
    }
}
