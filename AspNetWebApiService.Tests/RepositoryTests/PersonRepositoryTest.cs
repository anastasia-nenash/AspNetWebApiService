using AspNetWebApiService.Core.QueryableExtensions;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Tests.CreationDataContextMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AspNetWebApiService.Tests.RepositoryTests
{
    [TestClass]
    public class PersonRepositoryTest
    {
        IDataContext dataContext;
        InitializationDataContextForTests testData = new InitializationDataContextForTests();
        public PersonRepositoryTest()
        {
            dataContext = testData.GetMoqDataContext();
            QueryableExtensions.Includer = new IncluderForTests();
        }

        [TestMethod]
        public void AddOrUpdatePerson()
        {
            var personRepository = new PersonRepository(dataContext);
            personRepository.AddOrUpdatePerson(testData.People[0].FirstName, testData.People[0].MiddleName, testData.People[0].LastName, new DateTime(1995, 8, 21));
            Assert.AreEqual(testData.People.Count, 3);
            personRepository.AddOrUpdatePerson("Андрей", "Андреевич", "Андреев", new DateTime(1997, 1, 13));
            Assert.AreEqual(testData.People.Count, 4);
        }

        [TestMethod]
        public void DeletePersonById()
        {
            var personRepository = new PersonRepository(dataContext);
            personRepository.DeletePersonById(new Guid("00000000000000000000000000000001"));
            Assert.AreEqual(testData.People.Count, 2);
        }

        [TestMethod]
        public void DeletePersonByName()
        {
            var personRepository = new PersonRepository(dataContext);
            personRepository.DeletePersonByName(testData.People[0].LastName, testData.People[0].FirstName, testData.People[0].MiddleName);
            Assert.AreEqual(testData.People.Count, 2);
        }

        [TestMethod]
        public void GetAllBooksByPerson()
        {
            var personRepository = new PersonRepository(dataContext);
            var result = personRepository.GetAllBooksByPerson(testData.People[0].Id);
            Assert.AreEqual(result.Count, 1);
        }
    }
}
