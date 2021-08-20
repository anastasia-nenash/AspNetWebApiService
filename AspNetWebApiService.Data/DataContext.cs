using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AspNetWebApiService.Data.Models;

namespace AspNetWebApiService.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        /// <summary>
        /// Добавление данных в таблицу
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            Genre[] genres =  
            {
                new Genre() { Id = Guid.NewGuid(), GenreName = "Детектив" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Роман" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Антиутопия" },
            };
            Author[] authors =
            {
                new Author() { Id = Guid.NewGuid(), FirstName = "Агата", LastName = "Кристи" },
                new Author() { Id = Guid.NewGuid(), FirstName = "Джером", LastName = "Сэлинджер" },
                new Author() { Id = Guid.NewGuid(), FirstName = "Евгений", MiddleName = "Иванович", LastName = "Замятин" }
            };
            Book[] books =
            {
                new Book() { Id = Guid.NewGuid(), Name = "Убийство в Восточном экспрессе", AuthorId = authors[0].Id},
                new Book() { Id = Guid.NewGuid(), Name = "Над пропастью во ржи", AuthorId = authors[1].Id},
                new Book() { Id = Guid.NewGuid(), Name = "Мы", AuthorId = authors[2].Id},
            };
            Person[] people =
            {
                new Person() { Id = Guid.NewGuid(), FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов", DateOfBirth = new DateTime(1990, 11, 9)},
                new Person() { Id = Guid.NewGuid(), FirstName = "Сергей", MiddleName = "Сергеевич", LastName = "Сергеев", DateOfBirth = new DateTime(1995, 3, 6)},
                new Person() { Id = Guid.NewGuid(), FirstName = "Петр", MiddleName = "Петрович", LastName = "Петров", DateOfBirth = new DateTime(1999, 6, 28)}
            };
            LibraryCard[] libraryCards =
            {
                new LibraryCard() { Id = Guid.NewGuid(), BookId = books[1].Id, PersonId = people[2].Id, DateOfReturnBook = DateTime.Now.AddDays(-4)},
                new LibraryCard() { Id = Guid.NewGuid(), BookId = books[2].Id, PersonId = people[0].Id, DateOfReturnBook = DateTime.Now.AddDays(7)}
            };

            modelBuilder.Entity<Book>()
                        .HasMany(c => c.Genres)
                        .WithMany(s => s.Books)
                        .UsingEntity<Dictionary<string, object>>(
                        "Book_Genre_lnk",
                        j => j
                                .HasOne<Genre>()
                                .WithMany()
                                .HasForeignKey("GenreId"),
                        j => j
                                .HasOne<Book>()
                                .WithMany()
                                .HasForeignKey("BookId"),
                        j =>
                        {
                            j.HasKey("GenreId", "BookId");
                            j.HasData(new { GenreId = genres[0].Id, BookId = books[0].Id },
                                      new { GenreId = genres[1].Id, BookId = books[1].Id },
                                      new { GenreId = genres[2].Id, BookId = books[2].Id});
                        }
                        );

           


            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Person>().HasData(people);
            modelBuilder.Entity<LibraryCard>().HasData(libraryCards);
        }

        
    }
}
