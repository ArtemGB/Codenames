using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthDataLayer.Models
{
    /// <summary>
    /// Класс определяющий таблицу TablePlaer в базе данных
    /// </summary>
    [Table("TablePlayer")]
    public class PersonData
    {
        [Key]
        [Column("GUID")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column("UserName")]
        public string UserName { get; set; } = string.Empty;
        [Column("Email")]
        public string Email { get; set; } = string.Empty;
        //public string Phone { get; set; } = string.Empty;
        [Column("HashPass")]
        public string HashPass { get; set; } = string.Empty;
        [Column("Role")]
        public string Role { get; set; } = string.Empty;

    }
}
