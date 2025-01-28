using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAuthDataLayer.Interfaces;
using Config.Interfaces;

namespace ApiAuthDataLayer.Config
{
    public class ConfigMongo : IConfigForConnectionToBD
    {
        private string _dbName = "Auth";
        public string DataBaseName 
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        private string _connect = "127.0.0.1";
        public string ConnectTo 
        {
            get { return _connect; }
            set { _connect = value; }
        }
        private string _port = "27017";
        public string Port 
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _login = "";
        public string Login 
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password = "password";
        public string Password 
        {
            get { return _password; }
            set { _password = value; }
        }
        
        public void GetConfig()
        {
            return;
        }
    }
}
