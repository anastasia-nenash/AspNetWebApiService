using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Core.Interfaces;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiService.Core.Repositories
{
    public class BookRepository : IBookRepository
    {
        private IDataContext dataContext;

        public BookRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Book> GetBooksByAuthor(string lastName, string firstName, string middleName)
        {
            return dataContext.Books
                              .Include(x => x.Genres)
                              .Include(x => x.Author)
                              .Where(x => x.Author.LastName == lastName
                              && x.Author.FirstName == firstName
                              && x.Author.MiddleName == middleName);
        }

        public IEnumerable<Book> GetBooksByGenre(string genreName)
        {
            return dataContext.Books
                              .Include(x => x.Genres)
                              .Include(x => x.Author)
                              .Where(x => x.Genres.Any(x => x.GenreName == genreName));
        }

        public void AddBook(string bookName, string genreName, string authorName, string authorMidName, string authorLastName)
        {
            var book = new Book() { Id = Guid.NewGuid(), Name = bookName };
            var genre = dataContext.Genres.Where(x => x.GenreName == genreName).FirstOrDefault();
            var author = dataContext.Authors
                                    .Where(x => x.FirstName == authorName
                                                && x.MiddleName == authorMidName
                                                && x.LastName == authorLastName)
                                    .FirstOrDefault();
            if (genre != null)
            {
                book.Genres.Add(genre);
            }
            else
            {
                book.Genres.Add(new Genre() { Id = Guid.NewGuid(), GenreName = genreName });
            }
            if (author != null)
            {
                book.AuthorId = author.Id;
            }
            else
            {
                var newAuthor = new Author()
                {
                    Id = Guid.NewGuid(),
                    FirstName = authorName,
                    MiddleName = authorMidName,
                    LastName = authorLastName
                };
                dataContext.Authors.Add(newAuthor);
                book.AuthorId = newAuthor.Id;
            }
            dataContext.Books.Add(book);
            dataContext.SaveChanges();
        }

        public void DeleteBook(Guid bookId)
        {
            dataContext.Books.Remove(dataContext.Books.Find(bookId));
            dataContext.SaveChanges();
        }

        public Book AddOrDeleteGenre(string bookName, string genreName)
        {
            var book = dataContext.Books.Include(x => x.Genres).Include(x => x.Author)
                                        .Where(x => x.Name == bookName).FirstOrDefault();
            var genre = dataContext.Genres.Where(x => x.GenreName == genreName).FirstOrDefault();

            if (book.Genres.Any(x => x.GenreName == genreName))
            {
                book.Genres.RemoveAll(x => x.GenreName == genreName);
            }
            else
            {
                if (genre != null) book.Genres.Add(genre);
                else
                {
                    book.Genres.Add(new Genre() { Id = Guid.NewGuid(), GenreName = genreName });
                }
            }
            dataContext.SaveChanges();
            return book;
        }
    }
}
