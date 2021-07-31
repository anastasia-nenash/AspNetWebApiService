using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AspNetWebApiService.Models
{
    /// <summary>
    /// Человек
    /// </summary>
    public class HumanModel
    {
        /// <summary>
        /// Номер человека
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }
    }
}
