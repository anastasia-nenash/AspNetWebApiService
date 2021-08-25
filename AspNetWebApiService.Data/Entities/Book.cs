using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebApiService.Data.Entities
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book : Logging
    {
        /// <summary>
        /// Номер книги
        /// </summary> 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Название книги")]
        public string Name { get; set; }

        /// <summary>
        /// Номер автора книги
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        /// <summary>
        /// Жанр книги
        /// </summary>
        public List<Genre> Genres { get; set; } = new List<Genre>();

        /// <summary>
        /// Наличие книг у пользователей
        /// </summary>
        public List<LibraryCard> LibraryCards { get; set; } = new List<LibraryCard>();
    }
}
