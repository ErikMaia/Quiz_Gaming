using System.ComponentModel.DataAnnotations;
// representa as categorias de produtos disponíveis no restaurante. Contém atributos como nome e descrição.
namespace api.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}