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
    public class AuthorRepositoryTest
    {
        IDataContext dataContext;
        InitializationDataContextForTests testData = new InitializationDataContextForTests();
        public AuthorRepositoryTest()
        {
            dataContext = testData.GetMoqDataContext();
            QueryableExtensions.Includer = new IncluderForTests();           
        }
        
        [TestMethod]
        public void GetAuthors()
        {
            var authorRepository = new AuthorRepository(dataContext);
            var result = authorRepository.GetAuthors();
            Assert.AreEqual(result.Count, testData.Authors.Count);        
        }

        [TestMethod]
        public void GetBooksByAuthor()
        {
            var authorRepository = new AuthorRepository(dataContext);
            var result = (List<Book>)authorRepository.GetBooksByAuthor(testData.Authors[0].FirstName, testData.Authors[0].LastName);
            Assert.AreEqual(result[0].Name, testData.Books[0].Name);
        }

        [TestMethod]
        public void AddAuthor()
        {
            var authorRepository = new AuthorRepository(dataContext);
            authorRepository.AddAuthor("Майк", "", "Омер", "Внутри убийцы");
            Assert.AreEqual(authorRepository.GetAuthors().Count, 4);
        }

        [TestMethod]
        public void DeleteAuthor()
        {
            var authorRepository = new AuthorRepository(dataContext);
            authorRepository.DeleteAuthor(new Guid("00000000000000000000000000000001"));
            Assert.AreEqual(authorRepository.GetAuthors().Count, 2);
        }
    }
}
