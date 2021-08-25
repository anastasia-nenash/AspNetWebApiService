using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebApiService.Data.Entities
{
    /// <summary>
    /// Жанр книги
    /// </summary>
    public class Genre : Logging
    {
        /// <summary>
        /// Номер жанра
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Название жанра книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Жанр книги")]
        public string GenreName { get; set; }

        /// <summary>
        /// Книги жанра
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
