using OpenQA.Selenium;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteInstagram : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "https://www.instagram.com/";

        public void CustomAction(string url)
        {
            throw new System.NotImplementedException();
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string login, string password)
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            var loginInput = _driver.FindElement(By.Name("username"));
            loginInput.SendKeys(login);

            var passwordInput = _driver.FindElement(By.Name("password"));
            passwordInput.SendKeys(password);

            var loginButton = _driver.FindElement(By.ClassName("DhRcB"));
            loginButton.Click();
        }

        public void Like(string url)
        {
            return;
        }
    }
}