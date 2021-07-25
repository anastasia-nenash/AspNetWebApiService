using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiService.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Жанр книги
        /// </summary>
        public string Genre { get; set; }
    }
}
