using AspNetWebApiService.Core.Interfaces;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private  readonly IDataContext dataContext;
        private readonly IGenreRepository genreRepository;
        public GenreController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            genreRepository = new GenreRepository(dataContext);
        }

        /// <summary>
        /// Получить все жанры
        /// </summary>
        /// <returns>Список жанров</returns>
        [HttpGet]
        public ICollection<GenreModelDTO> GetAllGenres()
        {
            List<Genre> genres = genreRepository.GetAllGenres().ToList();
            List<GenreModelDTO> genreModelDTOs = new List<GenreModelDTO>();
            foreach (var genre in genres)
            {
                genreModelDTOs.Add(new GenreModelDTO(genre.GenreName));
            }
            return genreModelDTOs;
        }

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        [HttpPost]
        public void AddGenre(string genreName)
        {
            genreRepository.AddGenre(genreName);
        }

        /// <summary>
        /// Получить статистику Жанр - Количество
        /// </summary>
        /// <returns>Статистика Жанр-Количество</returns>
        [HttpGet("StatisticsGenres")]
        public Dictionary<string, int> StatisticsGenres()
        {
            return genreRepository.StatisticsGenres();
        }

        /// <summary>
        /// Удалить жанр
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        [HttpDelete]
        public void DeleteGenre(string genreName)
        {
            genreRepository.DeleteGenre(genreName);
        }
    }
}
