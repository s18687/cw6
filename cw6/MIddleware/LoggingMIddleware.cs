using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw6.MIddleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private string _fileName;
        private object body;
        private object query;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            if(context.Request != null)
            {
                string path = context.Request.Path;
                string method = context.Request.Method;
                string queryString = context.Request.QueryString.ToString();
                string bodyString = "";

                using(var reader=new StreamReader(context.Request.Body, Encoding.UTF8, true,1024, true))
                {
                    bodyString = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }
                using (var writer = File.AppendText(_fileName))
                {
                    string message = $"[{DateTime.Now}] {method} {path}{query}\n{body}";
                    writer.WriteLine(message);
                }

            }

            await _next(context);
        }
    }
}
