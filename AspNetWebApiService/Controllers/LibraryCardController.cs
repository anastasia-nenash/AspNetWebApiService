using AspNetWebApiService.Data;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {
        private DataContext dataContext;
        public ILibraryCardRepository libraryCardRepository;
        public LibraryCardController(DataContext dataContext = null)
        {
            this.dataContext = dataContext;
            libraryCardRepository = new LibraryCardRepository(dataContext);
        }

        /// <summary>
        /// Добавить запись, что человек взял книгу
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        /// <returns>Ок или отказ, если ты должник</returns>
        [HttpPost("PersonTakeBook")]
        public IActionResult PersonTakeBook(Guid bookId, Guid personId)
        {
            string result = libraryCardRepository.PersonTakeBook(bookId, personId);
            return Ok(result);
        }

        /// <summary>
        /// Человек вернул книгу
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        /// <returns>Ок или ошибка, что такой книги у пользователя нет</returns>
        [HttpPost("PersonReturnedBook")]
        public IActionResult PersonReturnedBook(Guid bookId, Guid personId)
        {
            if (dataContext.LibraryCards.FirstOrDefault(x => x.BookId == bookId && x.PersonId == personId) != null)
            {
                libraryCardRepository.PersonReturnedBook(bookId, personId);
                return Ok("Книга возвращена");
            }
            else
            {
                return BadRequest("Такой книги у пользователя не найдено");
            }
        }

        /// <summary>
        /// Получить всех должников
        /// </summary>
        /// <returns>Должник, название книги, время просрочки</returns>
        [HttpGet("GetAllDebtors")]
        public ICollection<object> GetAllDebtors()
        {
            return libraryCardRepository.GetAllDebtors();            
        }

        /// <summary>
        /// Продлить возврат книги
        /// </summary>
        /// <param name="bookId">Номер книги</param>
        /// <param name="personId">Номер человека</param>
        /// <param name="days">Количество дней</param>
        [HttpPost("ExtendDeadlineReturnBook")]
        public void ExtendDeadlineReturnBook(Guid bookId, Guid personId, int days)
        {
            libraryCardRepository.ExtendDeadlineReturnBook(bookId, personId, days);
        }
    }
}
