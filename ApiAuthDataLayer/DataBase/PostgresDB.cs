using ApiAuthDataLayer.Config;
using ApiAuthDataLayer.Interfaces;
using ApiAuthDataLayer.Models;
using Config.Interfaces;
using Microsoft.Extensions.Logging;


namespace ApiAuthDataLayer.DataBase
{
    /// <summary>
    /// Класс реализующий подключение к PG и работу с таблицей TablePlayers через EF. 
    /// </summary>
    public class PostgresDB :  IConnectableToDB
    {
        private static IConfigForConnectionToBD _config;
        private ContextPG _context;

        
        /// <summary>
        /// Определяем конструктор класса 
        /// </summary>
        public PostgresDB(IConfigForConnectionToBD connectSettings)
        {
            _config = connectSettings;
            _config.GetConfig();
            Console.WriteLine($"{this}: PostgresDB was crated.");
            _context = new ContextPG(connectSettings);
        }

        public async Task<bool> CreateNewPersonAsync(PersonData newPers)
        {
            Console.WriteLine($"{this}: async Creating new person.");
            try
            {
                Console.WriteLine($"{this}: checking old records.");
                PersonData? oldUser =  this._context.Users.Where(u => u.UserName == newPers.UserName).FirstOrDefault();
                if (oldUser == null)
                {
                    this._context.Add(newPers);
                    this._context.SaveChanges();
                    Console.WriteLine($"{this}: User {newPers.UserName} was created.");
                }
                else
                {
                    Console.WriteLine($"{this}: User with UserName {newPers.UserName} already exists.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{this}: Msg = {ex.Message}; Trace = {ex.StackTrace}");
                return false;
            }
        }

        public bool DeletePerson(PersonData newPers)
        {
            throw new NotImplementedException();
        }

        public PersonData GetPerson(string login, string email, string passHash)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonData> GetPersonAsync(string email)
        {
            Console.WriteLine($"\t{this}: async get old person.");
            try
            {
                Console.WriteLine($"\t{this}: checking old records.");
                PersonData? oldUser = this._context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
                if (oldUser != null)
                {
                    Console.WriteLine($"\t{this}: found old user with {oldUser.UserName}:{oldUser.Email}.");
                    return oldUser;
                }
                else
                {
                    throw new Exception($"\t{this}: There is no user with UserName = {email}.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"\t{this}: Msg = {ex.Message}; Trace = {ex.StackTrace}");
                return new PersonData();
            }
        }

        public bool HasPesson(string logon, string email)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(PersonData newPers)
        {
            throw new NotImplementedException();
        }

        bool IConnectableToDB.CreateNewPerson(PersonData newPers)
        {
            throw new NotImplementedException();
        }
    }
}
