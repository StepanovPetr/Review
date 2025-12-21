using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebSite.Common.Entities;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation
{
    /// <summary> Класс для запуска бота. </summary>
    public class BotRunning
    { 
        public Login[] Logins { get; set; }

        public string[] ProxyServers { get; set; }

        public IWebSite WebSite { get; set; }

        public string[] Urls { get; set; }

        /// <summary> Инициализирует эеземпляр класса <see cref="BotRunning"/>>.  </summary>
        /// <param name="settings"></param>
        /// <param name="proxyServers"></param>
        /// <param name="logins"></param>
        public BotRunning(Settings settings, string[] proxyServers, Login[] logins)
        {
            ProxyServers = proxyServers;
            Logins = logins;
        }

        public BotRunning()
        {
        }

        /// <summary> Метод запуска бота. </summary>
        public void Run()
        {
            ReviewRequest(Urls,  false, ProxyServers, 1);
        }

        /// <summary> Метод с логикой для отправки запроса. </summary>
        private void ReviewRequest(string[] urls, bool isLoop, string[] proxyList, int maxDegreeOfParallelism = 5)
        {
            foreach (var url in urls)
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
        }

        /// <summary> Метод с отправки запроса. </summary>
        private void Request(string proxy, string url, string login, string password)
        {
            var options = new FirefoxOptions
            {
                //Добавляем HTTP-прокси
                Proxy = new OpenQA.Selenium.Proxy()
                {
                    HttpProxy = $"{proxy}",
                    SslProxy = $"{proxy}",
                },
                //AcceptInsecureCertificates = true // если прокси с самоподписанными сертификатами
            };

            IWebDriver driver = new FirefoxDriver(options);
            try
            {
                WebSite.SetChromeDriver(driver);
                //site.Login(login, password);
                WebSite.CustomAction(url);
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