using System;
using System.Threading;
using OpenQA.Selenium;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteDreamJob : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://dreamjob.ru/employers/137032?review_id=3917522";
        //"https://dreamjob.ru/employers/43841?review_id=4001899";

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
            Thread.Sleep(9000);

            var button = _driver.FindElement(By.CssSelector(".bt.bt--32.bt--primary-link.icon-thumbs-up"));
            button.Click();

            Thread.Sleep(1000);
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}