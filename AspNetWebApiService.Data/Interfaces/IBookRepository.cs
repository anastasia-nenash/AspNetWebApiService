using System;
using System.Collections.Generic;
using AspNetWebApiService.Data.Models;

namespace AspNetWebApiService.Data.Interfaces
{
    /// <summary>
    /// Интерфейс книги
    /// </summary>
    public interface IBookRepository 
    {
        /// <summary>
        /// Получить список книг по автору
        /// </summary>
        /// <param name="lastName">Фамилия автора</param>
        /// <param name="firstName">Имя автора</param>
        /// <param name="middleName">Отчество автора</param>
        /// <returns>Список всех книг автора</returns>
        IEnumerable<Book> GetBooksByAuthor(string lastName, string firstName, string middleName);
        
        /// <summary>
        /// Получить список книг по жанру
        /// </summary>
        /// <param name="genreName">Жанр книги</param>
        /// <returns>Список книг по жанру</returns>
        IEnumerable<Book> GetBooksByGenre(string genreName);

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="bookName">Название книги</param>
        /// <param name="genreName">Жанр книги</param>
        /// <param name="authorName">Имя автора</param>
        /// <param name="authorMidName">Отчество автора</param>
        /// <param name="authorLastName">Фамили автора</param>
        void AddBook(string bookName, string genreName, string authorName, string authorMidName, string authorLastName);

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        void DeleteBook(Guid bookId);

        /// <summary>
        /// Добавить или удалить жанр у книги
        /// </summary>
        /// <param name="bookName">Название книги</param>
        /// <param name="genreName">Жанр книги</param>
        Book AddOrDeleteGenre(string bookName, string genreName);       
    }
}
