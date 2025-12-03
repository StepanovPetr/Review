namespace WebSite.Implementation;

public class BotRunningBuilder
{
    private readonly BotRunning _botRunning = new BotRunning();

    public static BotRunningBuilder CreateBuilder() => new BotRunningBuilder();

    public BotRunningBuilder SetProxyServers(string[] proxyServers)
    {
        _botRunning.ProxyServers = proxyServers;
        return this;
    }

    public BotRunningBuilder SetWebSites(string webSite)
    {
        _botRunning.WebSite = WebSiteFactory.GetWebSite(webSite);
        return this;
    }

    public BotRunningBuilder SetUrl(string url)
    {
        _botRunning.Url = url;
        return this;
    }

    public BotRunning Build() => _botRunning;
}