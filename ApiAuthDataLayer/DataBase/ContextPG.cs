using ApiAuthDataLayer.Models;
using Config.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ApiAuthDataLayer.DataBase
{
    public class ContextPG: DbContext
    {
        private IConfigForConnectionToBD _config;
        public ContextPG(IConfigForConnectionToBD config) 
        {
            _config = config;
        }
        public DbSet<PersonData> Users { get; set; }

        /// <summary>
        /// Настройка подключения 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseNpgsql($"Host={_config.ConnectTo};Port={_config.Port};Database={_config.DataBaseName};Username={_config.Login};Password={_config.Password}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{this}: MSG = {ex.Message}; TRC = {ex.StackTrace}");
            }
        }
        /// <summary>
        /// Fluent API для настройки маппинга моделей с таблицами, тут указано:
        /// 1. Настройка первичного ключа
        /// 2. Связей с др. таблицами пока нет
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonData>().HasKey(u => new { u.Id });
        }
    }
}
