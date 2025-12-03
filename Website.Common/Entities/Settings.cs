namespace WebSite.Common.Entities
{
    /// <summary> Настройки для запуска бота. </summary>
    public class Settings
    {
        /// <summary> Максимальное число потоков для запуска. </summary>
        public int MaxDegreeOfParallelism { get; set; }

        /// <summary> URL для запуска. </summary>
        public string Url { get; set; }

        /// <summary> Параметр отвечающий за то требуется ли аутентификация. </summary>
        public bool IsLogin { get; set; }

        /// <summary> Запуск действия в бескончном цикле для каждого потока. </summary>
        public bool IsLoop { get; set; }

        public string WebSite { get; set; }
    }
}