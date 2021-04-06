using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation
{
    public class WebSiteProfessorrating : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://professorrating.org/";

        public void CustomAction(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(120000);
            var elems = _driver
                .FindElements(By.CssSelector(".ng-scope .icon-star-empty"));

            for (var i = 0; i < elems.Count; i = i + 5) elems[i].Click();

            _driver.FindElement(By.Id("RecommendNo")).Click();
            _driver.FindElements(By.ClassName("btn")).LastOrDefault()?.Click();
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string login = "", string password = "")
        {
        }

        public void Like(string url)
        {
            return;
        }
    }
}