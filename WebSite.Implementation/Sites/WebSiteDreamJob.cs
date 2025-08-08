using System;
using System.Threading;
using System.Xml.Linq;
using OpenQA.Selenium;
using WebSite.Common.Helpers;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteDreamJob : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://dreamjob.ru/employers/137032";

        public void Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Like(string url)
        {
            throw new NotImplementedException();
        }

        public void CustomAction(string url)
        {
            _driver.Navigate().GoToUrl(BaseUrl);

            var button = _driver.FindElement(By.ClassName("review__useful"));
            button.Click();

            Thread.Sleep(1000);
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}