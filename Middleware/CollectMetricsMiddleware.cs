using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Services;

namespace Wsei_Lab5.Middleware
{
    public class CollectMetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsCollector _collector;

        public CollectMetricsMiddleware(RequestDelegate next, IMetricsCollector collector)
        {
            _next = next;
            _collector = collector;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            _collector.Record(context.Request.Method, context.Request.Path, context.Response.StatusCode);
        }
    }
}
