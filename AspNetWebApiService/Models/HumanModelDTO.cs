using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AspNetWebApiService.Models
{
    public class HumanModelDTO
    {
        [DisplayName("Фамилия")]      
        public string Surname { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }
    }
}
