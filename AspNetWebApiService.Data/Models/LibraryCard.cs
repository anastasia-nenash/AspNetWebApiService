using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebApiService.Data.Models
{
    /// <summary>
    /// Карточки библиотеки
    /// </summary>
    public class LibraryCard : Logging
    {
        /// <summary>
        /// Номер карточки
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер книги
        /// </summary>
        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book;

        /// <summary>
        /// Номер человека
        /// </summary>
        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person;

        /// <summary>
        /// Дата возврата книги
        /// </summary>
        public DateTime DateOfReturnBook { get; set; }
    }
}
