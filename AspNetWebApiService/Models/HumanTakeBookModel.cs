using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Номер человека")]
        public int IdHuman { get; set; }
        /// <summary>
        /// Номер книги
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Номер книги")]
        public int IdBook { get; set; }
        /// <summary>
        /// Дата и время получения книги человеком
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Дата и время получения книги человеком")]
        public DateTimeOffset DateReceiptOfBook { get; set; }
    }
}
