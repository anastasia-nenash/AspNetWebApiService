using AspNetWebApiService.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AspNetWebApiService.Models
{
    public class PersonModelDTO
    {
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Книги")]
        public ICollection<BookModelDTO> Books { get; set; }

        public PersonModelDTO(Person person, ICollection<BookModelDTO> books)
        {
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            DateOfBirth = person.DateOfBirth;
            Books = books;
        }

        public PersonModelDTO(Person person)
        {
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            DateOfBirth = person.DateOfBirth;
        }
    }
}
