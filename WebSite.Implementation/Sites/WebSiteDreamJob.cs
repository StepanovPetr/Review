using OpenQA.Selenium;
using System;
using System.Threading;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteDreamJob : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://dreamjob.ru/employers/43841?review_id=4157930о";
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
            try
            {
                _driver.Navigate().GoToUrl(url);
                Thread.Sleep(3000);

                IWebElement button = _driver.FindElement(By.CssSelector(".icon-thumbs-up"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

                js.ExecuteScript("document.querySelector('.icon-thumbs-up').click();");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}