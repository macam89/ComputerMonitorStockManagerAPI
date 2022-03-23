using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ComputerMonitorStockManager.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string realm;

        public BasicAuthMiddleware(RequestDelegate next, string realm)
        {
            this.next = next;
            this.realm = realm;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var basicUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1].Trim();

                var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(basicUsernamePassword));

                var username = usernamePassword.Split(':')[0];
                var password = usernamePassword.Split(':')[1];

                if (IsAuthorized(username, password))
                {
                    await next.Invoke(context);
                    return;
                }
            }
            
            context.Response.Headers["WWW-Authenticate"] = "Basic";

            if (!string.IsNullOrWhiteSpace(realm))
            {
                context.Response.Headers["WWW-Authenticate"] += $" realm=\"{realm}\"";
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }


        public bool IsAuthorized(string username, string password)
        {
            return username.Equals("test") && password.Equals("test");
        }
    }
}