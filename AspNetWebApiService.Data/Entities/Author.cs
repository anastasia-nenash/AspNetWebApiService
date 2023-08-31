using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebApiService.Data.Entities
{
    /// <summary>
    /// Автор книги
    /// </summary>
    public class Author : Logging
    {
        /// <summary>
        /// Номер автора
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя автора
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Имя автора")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество автора
        /// </summary>
        [DisplayName("Отчество автора")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия автора
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Фамилия автора")]
        public string LastName { get; set; }

        /// <summary>
        /// Книги автора
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
        
    }
}
