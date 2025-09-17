using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebSite.Common.Entities;
using WebSite.Common.Interfaces;
using WebSite.Implementation.Sites;
using Proxy = WebSite.Common.Entities.Proxy;

namespace WebSite.Implementation
{
    /// <summary> Класс для запуска бота. </summary>
    public class BotRunning
    {
        private readonly Login[] _logins;
        private readonly Proxy[] _proxyServers;
        private readonly Settings _settings;

        /// <summary> Инициализирует эеземпляр класса <see cref="BotRunning"/>>.  </summary>
        /// <param name="settings"></param>
        /// <param name="proxyServers"></param>
        /// <param name="logins"></param>
        public BotRunning(Settings settings, Proxy[] proxyServers, Login[] logins)
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
        private void ReviewRequest(string url, bool isLoop, Proxy[] proxyList, int maxDegreeOfParallelism = 5)
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
                        //RequestLoop(proxy, url, "", "");
                    }
                    else
                    {
                        Request(proxy, url, "", "");
                    }
                });
        }

        /// <summary> Метод с отправки запроса. </summary>
        private void Request(Proxy proxy, string url, string login, string password)
        {
            var options = new FirefoxOptions
            {
                //Добавляем HTTP-прокси
                Proxy = new OpenQA.Selenium.Proxy()
                {
                    HttpProxy = $"{proxy.Ip}:{proxy.Port}",
                    SslProxy = $"{proxy.Ip}:{proxy.Port}",
                },
                //AcceptInsecureCertificates = true // если прокси с самоподписанными сертификатами
            };

            IWebDriver driver = new FirefoxDriver(options);
            try
            {
                IWebSite site = new WebSiteDreamJob();
                site.SetChromeDriver(driver);

                //site.Login(login, password);
                site.CustomAction(url);

                File.AppendAllText("GoodProxy.txt", $"{proxy} {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                File.AppendAllText("BadProxy.txt", $"{proxy} {Environment.NewLine}");
            }
            finally
            {
                driver.Close();
            }
        }
    }
}