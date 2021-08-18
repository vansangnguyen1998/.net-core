using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace core_api.Middleware
{
    public class CheckPayload
    {
        private readonly RequestDelegate _next;
        public CheckPayload(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/product" && httpContext.Request.Method == HttpMethods.Post)
            {
                var req = httpContext.Request;
                var validBody = new List<string>() {"name", "price"};
                var formKeys = req.Form.Keys;
                foreach (var key in formKeys)
                {
                    if (validBody.FirstOrDefault(x => x == key) == null)
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await httpContext.Response.WriteAsync("Invalid payload");
                    }
                }

                await _next(httpContext);
            }
            else
            {

                // Thiết lập Header cho HttpResponse
                httpContext.Response.Headers.Add("throughCheckAcessMiddleware", new[] { DateTime.Now.ToString() });

                Console.WriteLine("CheckAcessMiddleware: Cho truy cập");

                // Chuyển Middleware tiếp theo trong pipeline
                await _next(httpContext);

            }
        }

    }
}