using System.ComponentModel.DataAnnotations;

namespace api.core.Models;
public class QuizzModel
{
    [Key]
    public int QuizzId { get; set; }

    [Required]
    public int Correct { get; set; }

    [Required]
    public string? Questions { get; set; }

    [Required]
    public string? FirstOption { get; set; }

    [Required]
    public string? SecondOption { get; set; }

    [Required]
    public string? ThirdOption { get; set; }
}
