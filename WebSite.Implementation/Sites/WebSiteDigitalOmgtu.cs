using System.Threading;
using OpenQA.Selenium;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteDigitalOmgtu : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://digital.omgtu.ru/";

        public void Login(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Like(string url)
        {
            throw new System.NotImplementedException();
        }

        public void CustomAction(string url)
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            Thread.Sleep(2000);

            var firstName = _driver.FindElement(By.Name("lastname"));
            firstName.Click();
            firstName.Clear();
            firstName.SendKeys("Иванов");
         
   
            var name = _driver.FindElement(By.Name("name"));
            name.SendKeys("Иван");

            var middleName = _driver.FindElement(By.Name("secondname"));
            middleName.SendKeys("Иванович");
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}