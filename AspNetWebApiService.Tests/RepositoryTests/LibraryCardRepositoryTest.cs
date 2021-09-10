using AspNetWebApiService.Core.QueryableExtensions;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Tests.CreationDataContextMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AspNetWebApiService.Tests.RepositoryTests
{
    [TestClass]
    public class LibraryCardRepositoryTest
    {
        IDataContext dataContext;
        InitializationDataContextForTests testData = new InitializationDataContextForTests();
        public LibraryCardRepositoryTest()
        {
            dataContext = testData.GetMoqDataContext();
            QueryableExtensions.Includer = new IncluderForTests();
        }

        [TestMethod]
        public void PersonTakeBook()
        {
            var libraryCardRepository = new LibraryCardRepository(dataContext);
            var result = libraryCardRepository.PersonTakeBook(new Guid("00000000000000000000000000000001"), new Guid("00000000000000000000000000000001"));
            Assert.AreEqual(result, "Нельзя получить новую книгу, пока не вернёшь старую!");
            result = libraryCardRepository.PersonTakeBook(new Guid("00000000000000000000000000000002"), new Guid("00000000000000000000000000000003"));
            Assert.AreEqual(result, "Книга получена");
        }

        [TestMethod]
        public void PersonReturnedBook()
        {
            var libraryCardRepository = new LibraryCardRepository(dataContext);
            libraryCardRepository.PersonReturnedBook(new Guid("00000000000000000000000000000001"), new Guid("00000000000000000000000000000001"));
            Assert.AreEqual(testData.LibraryCards.Count, 1);
        }

        [TestMethod]
        public void GetAllDebtors()
        {
            var libraryCardRepository = new LibraryCardRepository(dataContext);
            var result = libraryCardRepository.GetAllDebtors();
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void ExtendDeadlineReturnBook()
        {
            var libraryCardRepository = new LibraryCardRepository(dataContext);
            libraryCardRepository.ExtendDeadlineReturnBook(new Guid("00000000000000000000000000000001"), new Guid("00000000000000000000000000000001"), 7);
            Assert.AreEqual(libraryCardRepository.GetAllDebtors().Count, 0);
        }
    }
}
