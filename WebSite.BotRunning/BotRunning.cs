using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebSite.Common.Entities;
using WebSite.Common.Interfaces;
using WebSite.Implementation;

namespace WebSite.BotRunning
{
    public class BotRunning
    {
        private readonly Login[] _logins;
        private readonly string[] _proxyServers;
        private readonly Settings _settings;

        public BotRunning(Settings settings, string[] proxyServers, Login[] logins)
        {
            _settings = settings;
            _proxyServers = proxyServers;
            _logins = logins;
        }

        public void Run()
        {
            if (_settings.IsLogin == false)
                ReviewRequest(_settings.Url,  _settings.IsLoop, _proxyServers, _settings.MaxDegreeOfParallelism);
        }

        private void ReviewRequest(string url, bool isLoop, string[] proxyList, int maxDegreeOfParallelism = 5)
        {
            Parallel.ForEach(proxyList, new ParallelOptions
                {
                    CancellationToken = new CancellationToken(),
                    MaxDegreeOfParallelism = maxDegreeOfParallelism
                },
                proxy =>
                {
                    if (isLoop)
                    {
                        RequestLoop(proxy, url, "", "");
                    }
                    else
                    {
                        Request(proxy, url, "", "");
                    }
                });
        }

        private void RequestLoop(string proxy, string url, string login, string password)
        {
            while (true)
            {
                Request(proxy, url, login, password);
            }
        }

        private void Request(string proxy, string url, string login, string password)
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.Proxy = new Proxy
            {
                HttpProxy = proxy,
                SslProxy = proxy
            };
            IWebDriver driver = new ChromeDriver(".", options);
            try
            {
                IWebSite site = new WebSiteKonfpmfi();
                site.SetChromeDriver(driver);
                site.Login(login, password);
                site.Like(url);

                File.AppendAllText("GoodProxy.txt", $"{proxy} {Environment.NewLine}");
            }
            catch (Exception)
            {
                File.AppendAllText("BadProxy.txt", $"{proxy} {Environment.NewLine}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}