using Chat.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Middlewares {
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JWTCookiesMiddleware {
        private readonly RequestDelegate _next;

        public JWTCookiesMiddleware(RequestDelegate next) {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, CookieModel cookie) {
            string token = httpContext.Request.Cookies[cookie.CookieName];
            if (!string.IsNullOrEmpty(token))
                httpContext.Request.Headers.Add("Authorization", "Bearer " + token);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JWTCookiesMiddlewareExtensions {
        public static IApplicationBuilder UseJWTCookiesMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<JWTCookiesMiddleware>();
        }
    }
}
