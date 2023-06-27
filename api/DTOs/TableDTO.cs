using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class TableDTO
    {
        public int? TableId { get; set; }
        public bool IsFree { get; set; }
        public DateTime? TimesOpen { get; set; }
    }
}