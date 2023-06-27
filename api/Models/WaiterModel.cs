using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class WaiterModel
    {
        [Key]
        public int WaiterId { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public int Fone { get; set; }
    }
}