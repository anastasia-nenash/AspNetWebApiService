using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiService.Models
{
    public class HumanTakeBookModelDTO
    {
        [DisplayName("Дата получения книги")]
        public DateTimeOffset DateReceiptOfBook { get; set; }

        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DisplayName("Название книги")]
        public string Title { get; set; }

        [DisplayName("Автор книги")]
        public string AuthorName { get; set; }

        [DisplayName("Жанр книги")]
        public string Genre { get; set; }

        public HumanTakeBookModelDTO( DateTimeOffset dateReceiptOfBook, BookModelDTO book, HumanModelDTO human)
        {
            DateReceiptOfBook = dateReceiptOfBook;
            Surname = human.Surname;
            Name = human.Name;
            Patronymic = human.Patronymic;
            Title = book.Title;
            AuthorName = book.AuthorName;
            Genre = book.Genre;
        }
    }
}
