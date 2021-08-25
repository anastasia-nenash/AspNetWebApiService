using AspNetWebApiService.Core.Interfaces;
using AspNetWebApiService.Core.Repositories;
using AspNetWebApiService.Data.Entities;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDataContext dataContext;
        private readonly IPersonRepository personRepository;
        public PersonController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            personRepository = new PersonRepository(dataContext);
        }

        /// <summary>
        /// Добавить или обновить человека
        /// </summary>
        /// <param name="firstName">Имя человека</param>
        /// <param name="middleName">Отчество человека</param>
        /// <param name="lastName">Фамилия человека</param>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <returns></returns>
        [HttpPost("AddOrUpdatePerson")]
        public PersonModelDTO AddOrUpdatePerson(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            Person person = personRepository.AddOrUpdatePerson(firstName, middleName, lastName, dateOfBirth);                                  
            return new PersonModelDTO(person);
        }

        /// <summary>
        /// Удалить человека по номеру
        /// </summary>
        /// <param name="personId">Номер человека</param>
        /// <returns>Ок или ошибка, если такого номера нет</returns>
        [HttpDelete("DeletePersonById")]
        public IActionResult DeletePersonById(Guid personId)
        {
            if (dataContext.People.FirstOrDefault(x => x.Id == personId) != null)
            {
                personRepository.DeletePersonById(personId);
                return Ok();
            }
            else
            {
                return BadRequest("Такого человека не существует");
            }
        }

        /// <summary>
        /// Удалить человека по имени
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <returns>Ок или ошибка, если такоого человека нет</returns>
        [HttpDelete("DeletePersonByName")]
        public IActionResult DeletePersonByName(string lastName, string firstName, string middleName)
        {
            if (dataContext.People.FirstOrDefault(x => x.LastName == lastName
                                                  && x.FirstName == firstName
                                                  && x.MiddleName == middleName) != null)
            {
                personRepository.DeletePersonByName(lastName, firstName, middleName);
                return Ok();
            }
            else
            {
                return BadRequest("Такого человека не существует");
            }
        }

        /// <summary>
        /// Получить список всех книг человека
        /// </summary>
        /// <param name="personId">Номер человека</param>
        /// <returns>Книги человека с автором и жанром</returns>
        [HttpGet("GetAllBooksByPerson")]
        public ICollection<BookModelDTO> GetAllBooksByPerson(Guid personId)
        {
            var books = personRepository.GetAllBooksByPerson(personId);
            List<BookModelDTO> _bookModelDTO = new List<BookModelDTO>();
            foreach (var book in books)
            {
                _bookModelDTO.Add(new BookModelDTO(book.Name, book.Author.FirstName,
                                                   book.Author.MiddleName, book.Author.LastName,
                                                   book.Genres.Select(x => x.GenreName).ToList()));
            }
            return _bookModelDTO;
        }

    }
}
