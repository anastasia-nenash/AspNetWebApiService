using System.ComponentModel;

namespace AspNetWebApiService.Models
{
    public class GenreModelDTO
    {
        [DisplayName("Жанр книги")]
        public string GenreName { get; set; }

        public GenreModelDTO(string genreName)
        {
            GenreName = genreName;
        }
    }
}
