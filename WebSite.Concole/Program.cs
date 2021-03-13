using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using WebSite.BotRunning;
using WebSite.Common.Entities;
using WebSite.Common.Interfaces;
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

            var botRunning = new BotRunning(settings, proxyServers, null);
            botRunning.Run();
            Console.ReadLine();
        }
    }
}