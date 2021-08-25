using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebApiService.Data.Entities
{
    /// <summary>
    /// Человек, взявший книгу
    /// </summary>
    public class Person : Logging
    {
        /// <summary>
        /// Номер человека
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Наличие книг у пользователей
        /// </summary>
        public List<LibraryCard> LibraryCards { get; set; } = new List<LibraryCard>();
    }
}
