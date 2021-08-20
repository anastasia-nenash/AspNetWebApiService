using AspNetWebApiService.Data.Models;
using System;
using System.Collections.Generic;

namespace AspNetWebApiService.Data.Interfaces
{
    /// <summary>
    /// Интерфейс библиотеки
    /// </summary>
    public interface ILibraryCardRepository
    {
        /// <summary>
        /// Человек берет книгу
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        string PersonTakeBook(Guid bookId, Guid personId);

        /// <summary>
        /// Человек возвращает книгу
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        void PersonReturnedBook(Guid bookId, Guid personId);

        /// <summary>
        /// Получить всех должников
        /// </summary>
        /// <returns>Список должников</returns>
        ICollection<object> GetAllDebtors();

        /// <summary>
        /// Продлить срок возврата книги
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        /// <param name="days">Количество дней для продления</param>
        void ExtendDeadlineReturnBook(Guid bookId, Guid personId, int days);
    }
}
