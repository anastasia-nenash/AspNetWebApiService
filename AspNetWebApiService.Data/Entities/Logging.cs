using System;

namespace AspNetWebApiService.Data.Entities
{
    /// <summary>
    /// Журналирование записей
    /// </summary>
    public class Logging
    {
        /// <summary>
        /// Дата вставки записи
        /// </summary>
        public DateTime DateOfInsertionRecord { get; set; }

        /// <summary>
        /// Дата изменения записи
        /// </summary>
        public DateTime? DateOfChangeRecord { get; set; }

        /// <summary>
        /// Весрия записи
        /// </summary>
        public string RecordingVersion { get; set; }
    }
}
