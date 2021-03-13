using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebSite.Common.Interfaces
{
    public interface IWebSite
    {
        string BaseUrl { get; set; }
        
        void Login(string login, string password);

        void Like(string url);

        void SetChromeDriver(IWebDriver driver);
    }
}