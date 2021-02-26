using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutopark.Data.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        private static void SetUpLocale()
        {
            var customCulture = new CultureInfo("en-US");
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;
        }
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            SetUpLocale();
            await _next.Invoke(context);
        }
    }
}
