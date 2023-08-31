using AspNetWebApiService.Core.QueryableExtensions;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Tests.CreationDataContextMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetWebApiService.Tests.RepositoryTests
{
    [TestClass]
    public class GenreRepositoryTest
    {
        IDataContext dataContext;
        InitializationDataContextForTests testData = new InitializationDataContextForTests();
        public GenreRepositoryTest()
        {
            dataContext = testData.GetMoqDataContext();
            QueryableExtensions.Includer = new IncluderForTests();
        }

        [TestMethod]
        public void GetAllGenres()
        {
            var genreRepository = new GenreRepository(dataContext);
            var result = genreRepository.GetAllGenres();
            Assert.AreEqual(result.Count, testData.Genres.Count);
        }

        [TestMethod]
        public void AddGenre()
        {
            var genreRepository = new GenreRepository(dataContext);
            genreRepository.AddGenre("Роман");
            Assert.AreEqual(testData.Genres.Count, 4);
        }

        [TestMethod]
        public void StatisticsGenres()
        {
            var genreRepository = new GenreRepository(dataContext);
            var result = genreRepository.StatisticsGenres();
            foreach(var res in result)
            {
                Assert.AreEqual(res.Value, 1);
            }
        }

        [TestMethod]
        public void DeleteGenre()
        {
            var genreRepository = new GenreRepository(dataContext);
            genreRepository.DeleteGenre("Детектив");
            Assert.AreEqual(testData.Genres.Count, 2);
        }

    }
}
