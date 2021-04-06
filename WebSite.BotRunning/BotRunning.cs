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
    /// <summary> Класс для запуска бота. </summary>
    public class BotRunning
    {
        private readonly Login[] _logins;
        private readonly string[] _proxyServers;
        private readonly Settings _settings;

        /// <summary> Инициализирует эеземпляр класса <see cref="BotRunning"/>>.  </summary>
        /// <param name="settings"></param>
        /// <param name="proxyServers"></param>
        /// <param name="logins"></param>
        public BotRunning(Settings settings, string[] proxyServers, Login[] logins)
        {
            _settings = settings;
            _proxyServers = proxyServers;
            _logins = logins;
        }

        /// <summary> Метод запуска бота. </summary>
        public void Run()
        {
            if (_settings.IsLogin == false)
                ReviewRequest(_settings.Url,  _settings.IsLoop, _proxyServers, _settings.MaxDegreeOfParallelism);
        }

        /// <summary> Метод с логикой для отправки запроса. </summary>
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

        /// <summary> Метод с отправки запроса в цикле. </summary>
        private void RequestLoop(string proxy, string url, string login, string password)
        {
            while (true)
            {
                Request(proxy, url, login, password);
            }
        }

        /// <summary> Метод с отправки запроса. </summary>
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
                site.CustomAction(url);

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