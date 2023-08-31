using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Models;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Core.Interfaces;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Entities;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataContext dataContext;
        private readonly IBookRepository bookRepository;
        public BookController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            bookRepository = new BookRepository(dataContext);
        }

        /// <summary>
        /// Получить книги по автору
        /// </summary>
        /// <param name="lastName">Фамилия автора</param>
        /// <param name="firstName">Имя автора</param>
        /// <param name="middleName">Отчество автора</param>
        /// <returns>Книги автора с жанром</returns>
        [HttpGet("GetBooksByAuthor")]
        public IEnumerable<BookModelDTO> GetBooksByAuthor(string lastName, string firstName, string middleName)
        {

            var books = bookRepository.GetBooksByAuthor(lastName, firstName, middleName);
            List<BookModelDTO> _bookModelDTO = new List<BookModelDTO>();
            foreach (var book in books)
            {
                _bookModelDTO.Add(new BookModelDTO(book.Name, book.Author.FirstName,
                                                   book.Author.MiddleName, book.Author.LastName,
                                                   book.Genres.Select(x => x.GenreName).ToList()));
            }
            return _bookModelDTO;
        }

        /// <summary>
        /// Получить книги по жанру
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        /// <returns>Список книг с авторами</returns>
        [HttpGet("GetBooksByGenre")]
        public IEnumerable<BookModelDTO> GetBooksByGenre(string genreName)
        {
            var books = bookRepository.GetBooksByGenre(genreName);
            List<BookModelDTO> _bookModelDTO = new List<BookModelDTO>();
            foreach (var book in books)
            {
                _bookModelDTO.Add(new BookModelDTO(book.Name, book.Author.FirstName,
                                                   book.Author.MiddleName, book.Author.LastName,
                                                   book.Genres.Select(x => x.GenreName).ToList()));
            }
            return _bookModelDTO;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="bookName">Название книги</param>
        /// <param name="genreName">Название жанра</param>
        /// <param name="authorName">Имя автора</param>
        /// <param name="authorMidName">Отчество автора</param>
        /// <param name="authorLastName">Фамилия автора</param>
        /// <returns>Ок или ошибка, что такая книа есть</returns>
        [HttpPost]
        public IActionResult AddBook(string bookName, string genreName, string authorName, string authorMidName, string authorLastName)
        {
            if (dataContext.Books.Where(x => x.Name == bookName).FirstOrDefault() != null)
            {
                return BadRequest("Такая книга уже существует");
            }
            bookRepository.AddBook(bookName, genreName, authorName, authorMidName, authorLastName);
            return Ok();
        }

        /// <summary>
        /// Удалить книгу по номеру
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <returns>Ок или ошибка, что книга у пользователя</returns>
        [HttpDelete]
        public IActionResult DeleteBook(Guid bookId)
        {
            if (dataContext.LibraryCards.FirstOrDefault(x => x.BookId == bookId) == null)
            {
                bookRepository.DeleteBook(bookId);
                return Ok();
            }
            else
            {
                return BadRequest("Нельзя удалить, т.к. книга у пользователя");
            }
        }

        /// <summary>
        /// Добавить или удалить жанр
        /// </summary>
        /// <param name="bookName">Название книги</param>
        /// <param name="genreName">Название жанра</param>
        /// <returns>Книгу с добавленным или удаленным жанром</returns>
        [HttpPost("AddOrDeleteGenre")]
        public BookModelDTO AddOrDeleteGenre(string bookName, string genreName)
        {
            Book book = bookRepository.AddOrDeleteGenre(bookName, genreName);
            return new BookModelDTO(book.Name, book.Author.FirstName, book.Author.MiddleName,
                                    book.Author.LastName, book.Genres.Select(x => x.GenreName).ToList());
        }


    }
}
