using System.ComponentModel.DataAnnotations;
namespace api.core.Models;
public class ClassRoomModel
{
    [Key]
    public int ClassId {get;set;}
    [Required]
    public string? Description {get;set;} 
    public List<StudentModel>? Student {get;set;}
}
