using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public string Genre { get; set; }
    }
}
