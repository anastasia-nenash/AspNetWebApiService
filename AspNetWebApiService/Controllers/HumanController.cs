using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApiService.Models;
using Mapster;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        /// <summary>
        /// Список людей
        /// </summary>
        private static List<HumanModel> _humans = new List<HumanModel>()
        {
            new HumanModel()
            {
                Id = 0,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                DateOfBirth = new DateTime(1990, 11, 9),
            },
            new HumanModel()
            {
                Id = 1,
                Surname = "Сергеев",
                Name = "Сергей",
                Patronymic = "Сергеевич",
                DateOfBirth = new DateTime(1995, 3, 6),
            },
            new HumanModel()
            {
                Id = 2,
                Surname = "Петров",
                Name = "Петр",
                Patronymic = "Петрович",
                DateOfBirth = new DateTime(1999, 6, 28),
            }
        };
        
        /// <summary>
        /// Получить весь список людей
        /// </summary>
        /// <returns>Список людей</returns>
        [HttpGet]
        public IEnumerable<HumanModelDTO> Get()
        {
            return _humans.Adapt<IEnumerable<HumanModelDTO>>();
        }

        /// <summary>
        /// Получить человека по номеру
        /// </summary>
        /// <param name="id">Номер человека</param>
        /// <returns>Человек по немору</returns>
        [HttpGet("{id}/human")]
        public HumanModelDTO Get(int id)
        {
            return _humans.ElementAt(id).Adapt<HumanModelDTO>();
        }

        /// <summary>
        /// Вернуть список людей по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Список людей по имени</returns>
        [HttpGet("{name}")]
        public IEnumerable<HumanModelDTO> Get(string name)
        {
            return _humans.Where(c => c.Name == name).ToList().Adapt<IEnumerable<HumanModelDTO>>();
        }

        /// <summary>
        /// Добавить нового человека
        /// </summary>
        /// <param name="humanModel">Человек</param>
        /// <returns>Список всех людей</returns>
        [HttpPost]
        public IEnumerable<HumanModelDTO> Post([FromBody] HumanModel humanModel)
        {
            _humans.Add(humanModel);
            return _humans.Adapt<IEnumerable<HumanModelDTO>>();
        }

        /// <summary>
        /// Удалить человека по ФИО
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        [HttpDelete("{surname}")]
        public void Delete(string surname, string name, string patronymic)
        {
            _humans.RemoveAll(a => a.Surname == surname && a.Name == name && a.Patronymic == patronymic);
        }
    }
}
