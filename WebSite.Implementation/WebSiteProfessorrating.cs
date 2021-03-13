using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation
{
    public class WebSiteProfessorrating : IWebSite
    {
        private static string _reviewString = "" +
                                              "var elems = $('.ng-scope .icon-star-empty');" +
                                              "for (let i = 0; i < 30; i = i + 5) {" +
                                              "elems[i].click();" +
                                              "}" +
                                              "$('#RecommendNo').click();" +
                                              "$('.btn').last().click()";

        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://professorrating.org/";

        public void SetChromeDriver(IWebDriver driver)
         {
             _driver = driver;
         }

        public void Login(string login="", string password="")
        {
            return;
        }

        public void Like(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(120000);
            var elems = _driver
                .FindElements(By.CssSelector(".ng-scope .icon-star-empty"));

            for (int i = 0; i < elems.Count; i = i + 5)
            {
                elems[i].Click();
            }

            _driver.FindElement(By.Id("RecommendNo")).Click();
            _driver.FindElements(By.ClassName("btn")).LastOrDefault()?.Click();
        }
    }
}
