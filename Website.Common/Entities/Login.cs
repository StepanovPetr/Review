namespace WebSite.Common.Entities
{
    /// <summary> Настройки для авторизации. </summary>
    public class Login
    {
        /// <summary> Логин. </summary>
        public string LoginName { get; set; }

        /// <summary> Пароль. </summary>
        public string Password { get; set; }
    }
}