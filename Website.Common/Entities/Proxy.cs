namespace WebSite.Common.Entities
{
    /// <summary> Настройки для HTTP прокси. </summary>
    public class Proxy
    {
        /// <summary> Ip адрес. </summary>
        public string Ip { get; set; }

        /// <summary> Порт. </summary>
        public int Port { get; set; }

        /// <summary> Логин. </summary>
        public string Login { get; set; }

        /// <summary> Пароль. </summary>
        public string Password { get; set; }
    }
}