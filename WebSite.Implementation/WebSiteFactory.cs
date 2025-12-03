using OpenQA.Selenium;
using WebSite.Common.Constants;
using WebSite.Common.Interfaces;
using WebSite.Implementation.Sites;

namespace WebSite.Implementation;

public static class WebSiteFactory
{
    public static IWebSite GetWebSite(string webSite)
    {
        switch (webSite)
        {
            case WebSites.WebSiteDreamJob : return new WebSiteDreamJob();

            default: throw new NotFoundException("Неверный сайт.");
        }
    }
}