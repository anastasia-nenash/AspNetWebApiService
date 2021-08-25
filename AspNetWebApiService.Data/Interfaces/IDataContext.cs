using AspNetWebApiService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiService.Data.Interfaces
{
    public interface IDataContext 
    {
        DbSet<Book> Books { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<LibraryCard> LibraryCards { get; set; }

        int SaveChanges();
    }
}
