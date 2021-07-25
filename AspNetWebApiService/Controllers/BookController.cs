using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApiService.Models;


namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Список книг
        /// </summary>
        private static List<BookModel> _books = new List<BookModel>()
        {
            new BookModel()
            {
                Title = "Убийство в Восточном экспрессе",
                AuthorName = "Агата Кристи",
                Genre = "Детектив"
            },
            new BookModel()
            {
                Title = "Над пропастью во ржи",
                AuthorName = "Джером Сэлинджер",
                Genre = "Роман"
            },
            new BookModel()
            {
                Title = "Мы",
                AuthorName = "Е.И. Замятин",
                Genre = "Антиутопия"
            }
        };

        /// <summary>
        /// Получить список всех книг
        /// </summary>
        /// <returns>Список всех книг</returns>
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            return _books;
        }

        /// <summary>
        /// Получить список книг по автору
        /// </summary>
        /// <param name="authorName">Автор книги</param>
        /// <returns>Список книг по автору</returns>
        [HttpGet("{authorName}")]
        public IEnumerable<BookModel> Get(string authorName)
        {
            return _books.Where(c => c.AuthorName == authorName);
        }

        /// <summary>
        /// Добавить новую книгу
        /// </summary>
        /// <param name="bookModel">Книга</param>
        /// <returns>Список всех книг</returns>
        [HttpPost]
        public IEnumerable<BookModel> Post([FromBody] BookModel bookModel)
        {
            _books.Add(bookModel);
            return _books;
        }

        /// <summary>
        /// Удалить книгу по автору и названию
        /// </summary>
        /// <param name="authorName">Автор</param>
        /// <param name="title">Название книги</param>
        [HttpDelete("{authorName}")]
        public void Delete(string authorName, string title)
        {
            _books.RemoveAll(a => a.AuthorName == authorName && a.Title == title);
        }
    }
}
