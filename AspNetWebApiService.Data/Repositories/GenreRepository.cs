﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Models;
using System;

namespace AspNetWebApiService.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private DataContext dataContext;

        public GenreRepository(DataContext dataContext = null)
        {
            this.dataContext = dataContext;
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
