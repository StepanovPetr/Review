using System;
using System.Threading;
using OpenQA.Selenium;
using WebSite.Common.Helpers;
using WebSite.Common.Interfaces;

namespace WebSite.Implementation.Sites
{
    public class WebSiteKonfpmfi : IWebSite
    {
        private IWebDriver _driver;

        public string BaseUrl { get; set; } = "http://konfpmfi.omgtu.ru/?page_id=18";

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
            var rand = new Random();

            _driver.Navigate().GoToUrl(BaseUrl);
            var firstName = _driver.FindElement(By.Name("name1"));
            firstName.SendKeys(NameHelper.FirstNames[rand.Next(0, NameHelper.FirstNames.Length)]);

            var lastName = _driver.FindElement(By.Name("name2"));
            lastName.SendKeys(NameHelper.SecondNames[rand.Next(0, NameHelper.SecondNames.Length)]);

            var middleName = _driver.FindElement(By.Name("name3"));
            middleName.SendKeys(NameHelper.FirstNames[rand.Next(0, NameHelper.FirstNames.Length)]);

            var date = _driver.FindElement(By.Name("date-643"));
            date.SendKeys("15.04.2021");

            var addr = _driver.FindElement(By.Name("addr"));
            addr.SendKeys("Улица Пшкина, дом калатушкина 1");

            var email = _driver.FindElement(By.Name("email"));
            email.SendKeys("avzykina@mail.ru");

            var loginInput6 = _driver.FindElement(By.Name("tel"));
            loginInput6.SendKeys("123123123");

            var loginInput8 = _driver.FindElement(By.Name("doc"));
            loginInput8.SendKeys("Актуальность изучения методов оптимизации в получении профессии программист.");

            var annot = _driver.FindElement(By.Name("annot"));
            annot.SendKeys("Актуальность изучения методов оптимизации в получении профессии программист." +
                           "Актуальность изучения методов оптимизации в получении профессии программист." +
                           " Особенности изучения бд в техническом университете" +
                           "Актуальность изучения методов оптимизации в получении профессии программист." +
                           "Актуальность изучения методов оптимизации в получении профессии программист." +
                           " Особенности изучения бд в техническом университете" +
                           "Актуальность изучения методов оптимизации в получении профессии программист." +
                           "Актуальность изучения методов оптимизации в получении профессии программист." +
                           " Особенности изучения бд в техническом университете");

            var keyword = _driver.FindElement(By.Name("keyword"));
            keyword.SendKeys("Актуальность изучения методов оптимизации в получении профессии программист");

            var rffi = _driver.FindElement(By.Name("rffi"));
            rffi.SendKeys("-");

            var vremya = _driver.FindElement(By.Name("vremya"));
            vremya.SendKeys("С 1 апреля!!!");

            var vyz = _driver.FindElement(By.Name("vyz"));
            vyz.SendKeys("Омский государственный технический университет");

            var fak = _driver.FindElement(By.Name("fak"));
            fak.SendKeys("Информационных технологий и компьютерных ситем");

            var kaf = _driver.FindElement(By.Name("kaf"));
            kaf.SendKeys("Прикладная математика и фундаментальная информатика");

            var dop = _driver.FindElement(By.Name("dop"));
            dop.SendKeys("С 1 апреля!!!");

            var button = _driver.FindElement(By.ClassName("wpcf7-submit"));
            button.Click();

            Thread.Sleep(1000);
        }

        public void SetChromeDriver(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}