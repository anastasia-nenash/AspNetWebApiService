using System.Collections.Generic;
using System.ComponentModel;

namespace AspNetWebApiService.Models
{
    public class BookModelDTO
    {
        [DisplayName("Название книги")]
        public string Name { get; set; }

        [DisplayName("Автор книги")]
        public string AuthorName { get; set; }
        public string AuthorMiddleName { get; set; }
        public string AuthorLastName { get; set; }

        [DisplayName("Жанр книги")]
        public List<string> GenreNames { get; set; }

        public BookModelDTO(string name, string authorName, string authorMidName, string authorLastName, List<string> genreNames)
        {
            Name = name;
            AuthorName = authorName;
            AuthorMiddleName = authorMidName;
            AuthorLastName = authorLastName;
            GenreNames = genreNames;
        }

        public BookModelDTO(string name, string authorName, string authorMidName, string authorLastName)
        {
            Name = name;
            AuthorName = authorName;
            AuthorMiddleName = authorMidName;
            AuthorLastName = authorLastName;
        }
    }
}
