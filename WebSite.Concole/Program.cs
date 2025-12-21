using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using WebSite.Common.Entities;
using WebSite.Implementation;

namespace Review
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

            IConfiguration config = builder.Build();

            Settings settings = config.GetSection("Settings").Get<Settings>();
            var logins = config.GetSection("Logins").Get<Login[]>();
            var proxyServers = config.GetSection("ProxyServers").Get<string[]>();

            var botRunning = BotRunningBuilder.CreateBuilder()
                .SetUrl(settings.Urls)
                .SetProxyServers(proxyServers)
                .SetWebSites(settings.WebSite)
                .Build();
            
                botRunning.Run();

            Console.WriteLine("Work Done!!!");
        }
    }
}