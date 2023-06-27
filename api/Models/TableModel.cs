using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TableModel
    {
        [Key]
        public int TableId { get; set; }
        public bool IsFree { get; set; }
        public DateTime TimesOpen { get; set; }
    }
}