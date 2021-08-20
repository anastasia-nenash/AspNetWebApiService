using AspNetWebApiService.Data;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Models;
using AspNetWebApiService.Data.Repositories;
using AspNetWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private DataContext dataContext;
        public IAuthorRepository authorRepository;
        public AuthorController(DataContext dataContext = null)
        {
            this.dataContext = dataContext;
            authorRepository = new AuthorRepository(dataContext);
        }

        /// <summary>
        /// Получить список всех авторов
        /// </summary>
        /// <returns>Список авторов</returns>
        [HttpGet]
        public ICollection<AuthorModelDTO> GetAuthors()
        {
            List<Author> authors = authorRepository.GetAuthors().ToList();
            List<AuthorModelDTO> authorModelDTOs = new List<AuthorModelDTO>();
            foreach(var author in authors)
            {
                authorModelDTOs.Add(new AuthorModelDTO(author.FirstName, author.MiddleName, author.LastName));
            }
            return authorModelDTOs;
        }

        /// <summary>
        /// Получить книги по автору
        /// </summary>
        /// <param name="authorFirstName">Имя автора</param>
        /// <param name="authorLastName">Фамилия автора</param>
        /// <returns>Список книг по автору</returns>
        [HttpGet("GetBooksByAuthor")]
        public ICollection<BookModelDTO> GetBooksByAuthor(string authorFirstName, string authorLastName)
        {
            List<Book> books = authorRepository.GetBooksByAuthor(authorFirstName, authorLastName).ToList();
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
        /// Добавить автора
        /// </summary>
        /// <param name="firstName">Имя автора</param>
        /// <param name="middleName">Отчество автора</param>
        /// <param name="lastName">Фамилия автора</param>
        /// <param name="bookName">Название книги</param>
        /// <returns>Автор с книгами</returns>
        [HttpPost]
        public ICollection<BookModelDTO> AddAuthor(string firstName, string middleName, string lastName, string bookName)
        {
            authorRepository.AddAuthor(firstName, middleName, lastName, bookName);
            List<Book> books = authorRepository.GetBooksByAuthor(firstName, lastName).ToList();
            List<BookModelDTO> _bookModelDTO = new List<BookModelDTO>();
            foreach (var book in books)
            {
                _bookModelDTO.Add(new BookModelDTO(book.Name, book.Author.FirstName,
                                                   book.Author.MiddleName, book.Author.LastName));
            }
            return _bookModelDTO;
        }

        /// <summary>
        /// Удалить автора и его книги
        /// </summary>
        /// <param name="authorId">Номер автора</param>
        /// <returns>Ок или ошибка, если книги автора у пользователя</returns>
        [HttpDelete]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            var book = dataContext.Books.FirstOrDefault(x => x.AuthorId == authorId);
            
            if (book.Id != null && dataContext.LibraryCards.FirstOrDefault(x => x.BookId == book.Id) != null )
            {
                return BadRequest("Нельзя удалить автора, пока его книги у пользователя");
            }
            else
            {
                authorRepository.DeleteAuthor(authorId);
                return Ok();
            }
        }
    }
}
