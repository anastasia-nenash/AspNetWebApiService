using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApiService.Models;
using Mapster;


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
                Id = 0,
                Title = "Убийство в Восточном экспрессе",
                AuthorName = "Агата Кристи",
                Genre = "Детектив"
            },
            new BookModel()
            {
                Id = 1,
                Title = "Над пропастью во ржи",
                AuthorName = "Джером Сэлинджер",
                Genre = "Роман"
            },
            new BookModel()
            {
                Id = 2,
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
        public IEnumerable<BookModelDTO> Get()
        {
            return _books.Adapt<IEnumerable<BookModelDTO>>();
        }

        /// <summary>
        /// Получить книгу по номеру
        /// </summary>
        /// <param name="id">Номер книги</param>
        /// <returns>Книга по номеру</returns>
        [HttpGet("{id}")]
        public BookModelDTO Get(int id)
        {
            return _books.ElementAt(id).Adapt<BookModelDTO>();
        }

        /// <summary>
        /// Получить список книг по автору
        /// </summary>
        /// <param name="authorName">Автор книги</param>
        /// <returns>Список книг по автору</returns>
        [HttpGet("{authorName}")]
        public IEnumerable<BookModelDTO> Get(string authorName)
        {
            IEnumerable<BookModel> _booksDTOs = _books.Where(c => c.AuthorName == authorName)
                                                      .ToList();
            return _booksDTOs.Adapt<IEnumerable<BookModelDTO>>();
        }

        /// <summary>
        /// Добавить новую книгу
        /// </summary>
        /// <param name="bookModel">Книга</param>
        /// <returns>Список всех книг</returns>
        [HttpPost]
        public IEnumerable<BookModelDTO> Post([FromBody] BookModel bookModel)
        {
            _books.Add(bookModel);
            return _books.Adapt<IEnumerable<BookModelDTO>>();
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
