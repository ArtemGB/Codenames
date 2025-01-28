using ApiAuthDataLayer.Interfaces;
using ApiAuthDataLayer.Models;
using Config.Interfaces;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiAuthDataLayer.DataBase
{
    public class MongoDB : IConnectableToDB
    {
        private static IConfigForConnectionToBD _config;

        public MongoDB(IConfigForConnectionToBD connectSettings) 
        {
            _config = connectSettings;
            _config.GetConfig();
            Console.WriteLine($"{this}: MongoDB was crated.");
        }
 
        public bool CreateNewPerson(PersonData newPers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создание новой записи в БД. Email должен быть уникален. 
        /// </summary>
        /// <param name="newPers"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewPersonAsync(PersonData newPers)
        {
            Console.WriteLine($"{this}: async Creating new person.");
            try
            {
                Console.WriteLine($"{this}: checking old records.");
                MongoClient _client = new MongoClient($"mongodb://{_config.ConnectTo}:{_config.Port}");
                IMongoDatabase _database = _client.GetDatabase($"{_config.DataBaseName}");
                var collection = _database.GetCollection<PersonData>("Persons");
                using var cursor = await collection.FindAsync(new BsonDocument());
                List<PersonData> persons = cursor.ToList();

                if(persons.Where(p => p.Email.Equals(newPers.Email)).ToList().Count == 0)
                {
                    BsonDocument newUser = new BsonDocument
                    {
                        { "GUID", newPers.Id.ToString()},
                        {"Login", newPers.UserName},
                        {"Email", newPers.Email},
                        {"PasswordHash", newPers.HashPass},
                        {"RoleType", newPers.Role}
                    };
                    await collection.InsertOneAsync(newPers);

                    return true;
                }else
                {
                    Console.WriteLine($"{this}: email {newPers.Email} is not unique. Count = [{persons.Where(p => p.Email.Equals(newPers.Email)).ToList().Count}].");
                    return false;
                }

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
            Console.WriteLine($"{this}: async Getting person for {email}.");
            try
            {
                MongoClient _client = new MongoClient($"mongodb://{_config.ConnectTo}:{_config.Port}");
                IMongoDatabase _database = _client.GetDatabase($"{_config.DataBaseName}");
                var collection = _database.GetCollection<PersonData>("Persons");
                using var cursor = await collection.FindAsync(new BsonDocument());
                List<PersonData> persons = cursor.ToList();

                return persons.Where(p => p.Email.Equals(email)).FirstOrDefault(new PersonData());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MSG = {ex.Message}; TRACE = {ex.StackTrace}");
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
    }
}
