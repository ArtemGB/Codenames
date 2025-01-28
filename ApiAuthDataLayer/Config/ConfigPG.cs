using ApiAuthDataLayer.Interfaces;
using ApiAuthDataLayer.Models;
using Config.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiAuthDataLayer.Config
{
    public class ConfigPG : IConfigForConnectionToBD
    {

        private string _dbName = "Project";
        public string DataBaseName 
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        private string _connect = "localhost";
        public string ConnectTo 
        {
            get { return _connect; }
            set { _connect = value; }
        }
        private string _port = "5432";
        public string Port 
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _login = "postgres";
        public string Login 
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password = "1HUF!zLRnCKM-kV0";
        public string Password 
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Для реализации заполнения конфига по необходимости
        /// </summary>
        public void GetConfig()
        {
            return;
        }

        
    }
}
