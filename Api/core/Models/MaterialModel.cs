using System.ComponentModel.DataAnnotations;
namespace api.core.Models;
public class MaterialModel
{
    [Key]
    public int MaterialId { get; set; }
    [Required]
    public int MaterialType { get; set; }
    [Required]
    public string? Link { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Image { get; set; }
}
