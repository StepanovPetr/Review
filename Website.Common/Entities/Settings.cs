namespace WebSite.Common.Entities
{
    public class Settings
    {
        public int MaxDegreeOfParallelism { get; set; }

        public string Url { get; set; }

        public bool IsLogin { get; set; }

        public bool IsLoop { get; set; }
    }
}