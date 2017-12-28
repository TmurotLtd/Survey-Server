using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.API
{
    public static class CorsSupport
    {

        public static void HandlePreflightRequest(HttpContext context)
        {
            var req = context.Request;
            var res = context.Response;
            var origin = req.Headers["Origin"];

            if (!String.IsNullOrEmpty(origin))
            {

                // Here you can check if a certain domain makes requests

                res.AddHeader("Access-Control-Allow-Origin", origin);
                //  res.AddHeader("Access-Control-Allow-Credentials", "true");

                var methods = req.Headers["Access-Control-Request-Method"];
                var headers = req.Headers["Access-Control-Request-Headers"];

                if (!String.IsNullOrEmpty(methods))
                    res.AddHeader("Access-Control-Allow-Methods", methods);

                if (!String.IsNullOrEmpty(headers))
                    res.AddHeader("Access-Control-Allow-Headers", headers);

                if (req.HttpMethod == "OPTIONS")
                {
                    res.StatusCode = 204;
                    res.End();
                }
            }
        }

    }
}