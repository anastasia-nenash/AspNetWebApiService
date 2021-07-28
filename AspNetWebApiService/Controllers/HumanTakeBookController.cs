using AspNetWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanTakeBookController : ControllerBase
    {
        private static List<HumanTakeBookModel> _humanTakeBookModel = new List<HumanTakeBookModel>();

        /// <summary>
        /// Добавить запись о получении книги
        /// </summary>
        /// <param name="humanTakeBookModel">Человек взял книгу</param>
        /// <returns>Список записей о получении книг</returns>
        [HttpPost]
        public IEnumerable<HumanTakeBookModelDTO> Post([FromBody] HumanTakeBookModel humanTakeBookModel)
        {
            _humanTakeBookModel.Add(humanTakeBookModel);
            List<HumanTakeBookModelDTO> _humanTakeBookModelDTO = new List<HumanTakeBookModelDTO>();
            HumanController humanController = new HumanController();
            BookController bookController = new BookController();

            foreach (HumanTakeBookModel humanTakeBook in _humanTakeBookModel)
            {
                HumanModelDTO human = humanController.Get(humanTakeBook.IdHuman);
                BookModelDTO book = bookController.Get(humanTakeBook.IdBook);

                _humanTakeBookModelDTO.Add(new HumanTakeBookModelDTO(humanTakeBook.DateReceiptOfBook, book, human));
            }

            return _humanTakeBookModelDTO;
        }
    }
}
