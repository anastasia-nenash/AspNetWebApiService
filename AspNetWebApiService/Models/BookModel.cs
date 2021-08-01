using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspNetWebApiService.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Номер книги
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Название книги")]        
        public string Title { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Автор книги")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Жанр книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Жанр книги")]
        public string Genre { get; set; }
    }
}
