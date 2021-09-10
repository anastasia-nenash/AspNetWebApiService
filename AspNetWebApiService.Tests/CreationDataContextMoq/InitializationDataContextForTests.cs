using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace AspNetWebApiService.Tests.CreationDataContextMoq
{
    /// <summary>
    /// Заполнение данными Moq DbContext
    /// </summary>
    public class InitializationDataContextForTests
    {
        public InitializationDataContextForTests()
        {
            InitializeRelationInData();
        }

        /// <summary>
        /// Лист авторов
        /// </summary>
        private List<Author> _authors = new List<Author>
        {
            new Author { Id = new Guid("00000000000000000000000000000001"), FirstName = "Агата", MiddleName = "", LastName = "Кристи" },
            new Author { Id = Guid.NewGuid(), FirstName = "Евгений", MiddleName = "Иванович", LastName = "Замятин" },
            new Author { Id = Guid.NewGuid(), FirstName = "Стивен", MiddleName = "", LastName = "Кинг"}
        };

        /// <summary>
        /// Лист книг
        /// </summary>
        private List<Book> _books = new List<Book>
        {
            new Book { Id = new Guid("00000000000000000000000000000001"), Name = "Убийство в Восточном экспрессе" },
            new Book { Id = new Guid("00000000000000000000000000000002"), Name = "Мы" },
            new Book { Id = new Guid("00000000000000000000000000000003"), Name = "Оно" }
        };

        /// <summary>
        /// Лист жанров
        /// </summary>
        private List<Genre> _genres = new List<Genre>
        {
            new Genre() { Id = Guid.NewGuid(), GenreName = "Детектив" },
            new Genre() { Id = Guid.NewGuid(), GenreName = "Антиутопия" },
            new Genre() { Id = Guid.NewGuid(), GenreName = "Ужасы" }
        };

        /// <summary>
        /// Лист людей
        /// </summary>
        private List<Person> _people = new List<Person>
        {
            new Person() { Id = new Guid("00000000000000000000000000000001"), FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов", DateOfBirth = new DateTime(1990, 11, 9)},
            new Person() { Id = new Guid("00000000000000000000000000000002"), FirstName = "Сергей", MiddleName = "Сергеевич", LastName = "Сергеев", DateOfBirth = new DateTime(1995, 3, 6)},
            new Person() { Id = new Guid("00000000000000000000000000000003"), FirstName = "Петр", MiddleName = "Петрович", LastName = "Петров", DateOfBirth = new DateTime(1999, 6, 28)}
        };

        /// <summary>
        /// Лист карточек библиотеки
        /// </summary>
        private List<LibraryCard> _libraryCards = new List<LibraryCard>
        {
            new LibraryCard() { Id = Guid.NewGuid(), PersonId = new Guid("00000000000000000000000000000001"), BookId = new Guid("00000000000000000000000000000001"), DateOfReturnBook = DateTime.Now.AddDays(-4)},
            new LibraryCard() { Id = Guid.NewGuid(), PersonId = new Guid("00000000000000000000000000000003"), BookId = new Guid("00000000000000000000000000000003"), DateOfReturnBook = DateTime.Now.AddDays(7) }
        };

        public List<Author> Authors { get => _authors; }
        public List<Book> Books { get => _books; }
        public List<Genre> Genres { get => _genres; }
        public List<Person> People { get => _people; }
        public List<LibraryCard> LibraryCards { get => _libraryCards; }

        /// <summary>
        /// Отношения в бд
        /// </summary>
        private void InitializeRelationInData()
        {
            for (int i = 0; i < 3; i++)
            {
                _authors[i].Books = new List<Book>() { _books[i] };
                _books[i].Author = _authors[i];
                _books[i].Genres = new List<Genre>() { _genres[i] };
                _genres[i].Books = new List<Book>() { _books[i] };
            }

            _people[0].LibraryCards = new List<LibraryCard>() { _libraryCards[0] };
            _people[2].LibraryCards = new List<LibraryCard>() { _libraryCards[1] };

            _libraryCards[0].Person = _people[0];
            _libraryCards[1].Person = _people[2];

            _books[0].LibraryCards = new List<LibraryCard>() { _libraryCards[0] };
            _books[2].LibraryCards = new List<LibraryCard>() { _libraryCards[1] };

            _libraryCards[0].Book = _books[0];
            _libraryCards[1].Book = _books[2];
        }

        /// <summary>
        /// Получить заполненный Moq DbContext
        /// </summary>
        /// <returns>Moq DbContext</returns>
        public IDataContext GetMoqDataContext()
        {
            var dataContextMock = new Mock<IDataContext>();

            dataContextMock.Setup(p => p.Authors).Returns(DataContextMoq.GetQueryableMockDbSet<Author>(_authors).Object);
            dataContextMock.Setup(p => p.Books).Returns(DataContextMoq.GetQueryableMockDbSet<Book>(_books).Object);
            dataContextMock.Setup(p => p.Genres).Returns(DataContextMoq.GetQueryableMockDbSet<Genre>(_genres).Object);
            dataContextMock.Setup(p => p.LibraryCards).Returns(DataContextMoq.GetQueryableMockDbSet<LibraryCard>(_libraryCards).Object);
            dataContextMock.Setup(p => p.People).Returns(DataContextMoq.GetQueryableMockDbSet<Person>(_people).Object);
            dataContextMock.Setup(p => p.SaveChanges()).Returns(1);

            return dataContextMock.Object;
        }
    }
}
