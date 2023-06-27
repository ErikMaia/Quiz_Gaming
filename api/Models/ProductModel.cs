using System.ComponentModel.DataAnnotations;
namespace api.Models;

// e presenta os produtos disponíveis no restaurante. Contém atributos como nome, descrição, preço e categoria.
public class ProductModel
{
    [Key]
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public CategoryModel? Category { get; set; }
}
