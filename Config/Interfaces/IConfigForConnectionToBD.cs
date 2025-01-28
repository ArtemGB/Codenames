namespace Config.Interfaces
{
    /// <summary>
    /// Для реализации получения настроек к БД
    /// </summary>
    public interface IConfigForConnectionToBD
    {
        string DataBaseName { get; set; }
        public string ConnectTo { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Для смены настроек
        /// </summary>
        public void GetConfig();
    }
}
