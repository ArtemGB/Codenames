using ApiAuthDataLayer.Interfaces;
using ApiAuthDataLayer.Models;
using Microsoft.Extensions.Logging;


namespace ApiAuthBusinessLayer
{
    /// <summary>
    /// Класс для создания нового пользователя
    /// </summary>
    public class TryCreateNewUser
    {
        public TryCreateNewUser()
        {
            Console.WriteLine($"{this}: create TryCreateNewUser.");
        }

        public async Task<bool> CreateUniqueUserAsync(IConnectableToDB connection, PersonData newPerson)
        {
            Console.WriteLine($"{this}: try to add new user.");
            try
            {
                newPerson.HashPass = GetHashFromPassword.GetdHash(newPerson.HashPass);
                return await connection.CreateNewPersonAsync(newPerson);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{this}: MSG  = {ex.Message}; TRC = {ex.StackTrace}.");
                return false;
            }
        }
    }
}
