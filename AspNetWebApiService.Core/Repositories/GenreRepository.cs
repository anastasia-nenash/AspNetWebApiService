using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Core.Interfaces;
using System;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Core.QueryableExtensions;

namespace AspNetWebApiService.Core.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private IDataContext dataContext;

        public GenreRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        static GenreRepository()
        {
            QueryableExtensions.QueryableExtensions.Includer
                = QueryableExtensions.QueryableExtensions.Includer ?? new DbIncluder();
        }

        public ICollection<Genre> GetAllGenres()
        {
            return dataContext.Genres.ToList();
        }
        public void AddGenre(string genreName)
        {
            dataContext.Genres.Add(new Genre() { Id = Guid.NewGuid(), GenreName = genreName });
            dataContext.SaveChanges();
        }
        public Dictionary<string, int> StatisticsGenres()
        {
            var genres = dataContext.Genres.ToList();
            Dictionary<string, int> statistics = new Dictionary<string, int>();
            foreach (var g in genres)
            {
                var books = dataContext.Books.Include(x => x.Genres).Where(x => x.Genres.Any(x => x.Id == g.Id)).ToList();
                statistics.Add(g.GenreName, books.Count);
            }
            return statistics;
        }

        public void DeleteGenre(string genreName)
        {
            var genre = dataContext.Genres.FirstOrDefault(x => x.GenreName == genreName);
            dataContext.Genres.Remove(genre);
            dataContext.SaveChanges();
        }
    }
}
