using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace core_api.Middleware
{
    public class ValidationData
    {
        private readonly RequestDelegate _next;
        public ValidationData(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/product" && httpContext.Request.Method == HttpMethods.Post)
            {
                var req = httpContext.Request;

                if (int.Parse(req.Form["price"].ToString()) < 100)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    await httpContext.Response.WriteAsync("Price have to gather than 100");
                }
                else
                {

                    // Thiết lập Header cho HttpResponse
                    httpContext.Response.Headers.Add("throughCheckAcessMiddleware", new[] {DateTime.Now.ToString()});

                    Console.WriteLine("CheckAcessMiddleware: Cho truy cập");
                    
                    await _next(httpContext);

                }

            }

            await _next(httpContext);
        }
    }
}