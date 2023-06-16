using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseEntity
    {
        /// <summary>
        ///     Дата создания
        /// </summary>
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        ///     Дата обновления
        /// </summary>
        public DateTimeOffset? UpdateDate { get; set; }

        /// <summary>
        ///     Удалена
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
