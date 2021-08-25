using AspNetWebApiService.Data.Entities;
using System.Collections.Generic;

namespace AspNetWebApiService.Core.Interfaces
{
    /// <summary>
    /// Интерфейс жанра книги
    /// </summary>
    public interface IGenreRepository 
    {
        /// <summary>
        /// Получить список всех жанров
        /// </summary>        
        /// <returns>Список всех жанров</returns>
        ICollection<Genre> GetAllGenres();

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        void AddGenre(string genreName);

        /// <summary>
        /// Вывести статистику по жанру
        /// </summary>
        /// <returns>Название жанра и количество книг</returns>
        Dictionary<string, int> StatisticsGenres();

        /// <summary>
        /// Удалить жанр
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        void DeleteGenre(string genreName);
    }
}
