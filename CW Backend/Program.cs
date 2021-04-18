using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Licensing.RegisterLicense("TRIAL30WEB-e1JlZjpUUklBTDMwV0VCLE5hbWU6NC8xNC8yMDIxIDdiYzhlOWFkNWYzYTRhMTY4OTNjYzhjOWEzNzVlZTc3LFR5cGU6VHJpYWwsTWV0YTowLEhhc2g6TjZFdFFBRlo1R3dnZTBJSjhoNjd4Z3JWS0s0M25nck9LV1QrblRhV0N6Y3BqNXczdW9hdUQrSzVKb2lNdzd3bFV6Yzg2S3lyMVhFOTFsa0swUEl0S0FzWk5JM2c3YWtCNDZyOVYwQXhuRFNHNkdxenJwR2NEd1ZtSnlNY2h5QXlPQUpiaTFzTmtGekN0Y1ZCRjl1WnkvN0hQREJoaUxRQWp6dGxMQk9sY1pRPSxFeHBpcnk6MjAyMS0wNS0xNH0=");
            await DatabaseController.ConnectToDatabase("localhost", "regcourtcases", "regcourtcases", "W1k7L9m9J2i9F1d5" );//"DebugEnabled");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
