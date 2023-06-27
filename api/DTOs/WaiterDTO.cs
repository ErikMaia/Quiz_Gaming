using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class WaiterDTO
    {
        public int? WaiterId { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public int? Fone { get; set; }
    }
}