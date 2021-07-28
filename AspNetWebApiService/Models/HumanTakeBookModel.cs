using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiService.Models
{
    /// <summary>
    /// Человек взял книгу
    /// </summary>
    public class HumanTakeBookModel
    {
        /// <summary>
        /// Номер получения книги человеком
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Номер человека
        /// </summary>
        public int IdHuman { get; set; }
        /// <summary>
        /// Номер книги
        /// </summary>
        public int IdBook { get; set; }
        /// <summary>
        /// Дата и время получения книги человеком
        /// </summary>
        public DateTimeOffset DateReceiptOfBook { get; set; }
    }
}
