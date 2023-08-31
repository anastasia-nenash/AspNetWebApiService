using AspNetWebApiService.Data.Entities;
using System;
using System.Collections.Generic;



namespace AspNetWebApiService.Core.Interfaces
{
    /// <summary>
    /// Интерфейс автора
    /// </summary>
    public interface IAuthorRepository 
    {
        /// <summary>
        /// Получить список авторов
        /// </summary>
        /// <returns>Список авторов</returns>
        ICollection<Author> GetAuthors();
        
        /// <summary>
        /// Получить книги по автору
        /// </summary>
        /// <param name="authorFirstName">Имя автора</param>
        /// <param name="authorLastName">Фамилия автора</param>
        /// <returns>Список книг по автору</returns>
        ICollection<Book> GetBooksByAuthor(string authorFirstName, string authorLastName);

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="firstName">Имя автора</param>
        /// <param name="middleName">Отчество автора</param>
        /// <param name="lastName">Фамилия автора</param>
        /// <param name="bookName">Название книги</param>
        void AddAuthor(string firstName, string middleName, string lastName, string bookName);

        /// <summary>
        /// Удалить автора
        /// </summary>
        /// <param name="authorId">Номер автора</param>
        void DeleteAuthor(Guid authorId);
    }
}
