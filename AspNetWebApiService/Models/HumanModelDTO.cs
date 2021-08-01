using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public DateTime DateOfBirth { get; set; }
    }
}
