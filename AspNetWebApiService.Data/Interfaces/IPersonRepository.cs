using System;
using System.Collections.Generic;
using AspNetWebApiService.Data.Models;

namespace AspNetWebApiService.Data.Interfaces
{
    /// <summary>
    /// Интерфейс человека
    /// </summary>
    public interface IPersonRepository 
    {
        /// <summary>
        /// Добавить или обновить человека
        /// </summary>
        /// <param name="firstName">Имя человека</param>
        /// <param name="middleName">Отчество человека</param>
        /// <param name="lastName">Фамилия человека</param>
        /// <param name="dateOfBirth">Дата рождения человека</param>
        /// <returns>Добавленный или обновленный человек</returns>
        Person AddOrUpdatePerson(string firstName, string middleName, string lastName, DateTime dateOfBirth);

        /// <summary>
        /// Удалить человека по номеру
        /// </summary>
        /// <param name="personId">Номер человека</param>
        void DeletePersonById(Guid personId);

        /// <summary>
        /// Удалить человека по ФИО
        /// </summary>
        /// <param name="lastName">Фамилия человека</param>
        /// <param name="firstName">Имя человека</param>
        /// <param name="middleName">Отчество человека</param>
        void DeletePersonByName(string lastName, string firstName, string middleName);

        /// <summary>
        /// Книги, которые взял человек
        /// </summary>
        /// <param name="personId">Номер человека</param>
        /// <returns>Список книг, которые взял человек</returns>
        ICollection<Book> GetAllBooksByPerson(Guid personId);

    }
}
