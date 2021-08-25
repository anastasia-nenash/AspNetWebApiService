using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Core.Interfaces;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiService.Core.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private IDataContext dataContext;

        public AuthorRepository(IDataContext dataContext)
        {
           
            this.dataContext = dataContext;
        }

        public ICollection<Author> GetAuthors()
        {
            return dataContext.Authors.ToList();
        }

        public ICollection<Book> GetBooksByAuthor(string authorFirstName, string authorLastName)
        {
            return dataContext.Books
                              .Include(x => x.Genres)
                              .Include(x => x.Author)
                              .Where(x => x.Author.FirstName == authorFirstName
                                     && x.Author.LastName == authorLastName)
                              .ToList();
        }

        public void AddAuthor(string firstName, string middleName, string lastName, string bookName)
        {
            var book = dataContext.Books.FirstOrDefault(x => x.Name == bookName);
            Author author = new Author()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName
            };
            dataContext.Authors.Add(author);
            if (book == null && bookName != null)
            {
                book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Name = bookName
                };
                book.AuthorId = author.Id;
                dataContext.Books.Add(book);               
            }
            dataContext.SaveChanges();            
        }

        public void DeleteAuthor(Guid authorId)
        {
            List<Book> books = dataContext.Books.Include(x => x.Author).Where(x => x.AuthorId == authorId).ToList();
            foreach(var book in books)
            {
                dataContext.Books.Remove(book);
            }
            dataContext.Authors.Remove(dataContext.Authors.FirstOrDefault(x => x.Id == authorId));
            dataContext.SaveChanges();
        }
    }
}
