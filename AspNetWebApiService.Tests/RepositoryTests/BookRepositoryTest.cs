using AspNetWebApiService.Core.QueryableExtensions;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Tests.CreationDataContextMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AspNetWebApiService.Tests.RepositoryTests
{
    [TestClass]
    public class BookRepositoryTest
    {
        IDataContext dataContext;
        InitializationDataContextForTests testData = new InitializationDataContextForTests();
        public BookRepositoryTest()
        {
            dataContext = testData.GetMoqDataContext();
            QueryableExtensions.Includer = new IncluderForTests();
        }

        [TestMethod]
        public void GetBooksByAuthor()
        {
            var bookRepository = new BookRepository(dataContext);
            var result = (List<Book>)bookRepository.GetBooksByAuthor(testData.Authors[0].LastName, testData.Authors[0].FirstName, testData.Authors[0].MiddleName);
            Assert.AreEqual(result[0].Name, testData.Books[0].Name);
        }

        [TestMethod]
        public void GetBooksByGenre()
        {
            var bookRepository = new BookRepository(dataContext);
            var result = (List<Book>)bookRepository.GetBooksByGenre(testData.Genres[0].GenreName);
            Assert.AreEqual(result[0].Name, testData.Books[0].Name);
        }

        [TestMethod]
        public void AddBook()
        {
            var bookRepository = new BookRepository(dataContext);
            bookRepository.AddBook("Внутри убийцы", "Детектив", "Майк", "", "Омер");
            Assert.AreEqual(testData.Books.Count, 4);
            Assert.AreEqual(testData.Genres.Count, 3);
            Assert.AreEqual(testData.Authors.Count, 4);
        }

        [TestMethod]
        public void DeleteBook()
        {
            var bookRepository = new BookRepository(dataContext);
            bookRepository.DeleteBook(new Guid("00000000000000000000000000000001"));
            Assert.AreEqual(testData.Books.Count, 2);
        }

        [TestMethod]
        public void AddOrDeleteGenre()
        {
            var bookRepository = new BookRepository(dataContext);
            bookRepository.AddOrDeleteGenre(testData.Books[0].Name, testData.Genres[0].GenreName);
            Assert.AreEqual(testData.Books[0].Genres.Count, 0);
            bookRepository.AddOrDeleteGenre(testData.Books[0].Name, testData.Genres[0].GenreName);
            Assert.AreEqual(testData.Books[0].Genres.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddOrDeleteGenreException()
        {
            var bookRepository = new BookRepository(dataContext);
            bookRepository.AddOrDeleteGenre("Война и мир", "Роман");
        }
    }
}
