using ApiAuthDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuthDataLayer.Interfaces
{
    /// <summary>
    /// Реализуем подклчюение к ДБ и работу с ней
    /// </summary>
    public interface IConnectableToDB  
    {
        /// <summary>
        /// Проверка на наличие пользователя в БД
        /// </summary>
        /// <param name="logon"></param>
        /// <param name="email"></param>
        /// <param name="passHash"></param>
        /// <returns></returns>
        public bool HasPesson(string logon = "", string email = "");

        /// <summary>
        /// Поиск пользователя по логину\почте и проврка его пароля
        /// </summary>
        /// <param name="logon"></param>
        /// <param name="email"></param>
        /// <param name="passHash"></param>
        /// <returns></returns>
        public PersonData GetPerson(string login = "", string email = "", string passHash = "");

        /// <summary>
        /// Асинхронный поиск пользователя по логину\почте и проврка его пароля
        /// </summary>
        /// <param name="logon"></param>
        /// <param name="email"></param>
        /// <param name="passHash"></param>
        /// <returns></returns>
        public  Task<PersonData> GetPersonAsync(string email);

        /// <summary>
        /// Создание нового пользователя в БД
        /// </summary>
        /// <param name="newPers"></param>
        /// <returns></returns>
        public bool CreateNewPerson(PersonData newPers);

        /// <summary>
        /// Ассинхронное создание записи нового опльзователя
        /// </summary>
        /// <param name="newPers"></param>
        /// <returns></returns>
        public  Task<bool> CreateNewPersonAsync(PersonData newPers);

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <param name="newPers"></param>
        /// <returns></returns>
        public bool UpdatePerson(PersonData newPers);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="newPers"></param>
        /// <returns></returns>
        public bool DeletePerson(PersonData newPers);
    }
}
