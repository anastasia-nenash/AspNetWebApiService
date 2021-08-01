using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspNetWebApiService.Models
{
    public class BookModelDTO
    {                     
        [DisplayName("Название книги")]
        public string Title { get; set; }

        [DisplayName("Автор книги")]        
        public string AuthorName { get; set; }

        [DisplayName("Жанр книги")]
        [JsonIgnore]
        public string Genre { get; set; }
    }
}
