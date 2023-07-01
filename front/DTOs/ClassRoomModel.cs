namespace api.DTOs;
public class ClassRoomDTO
{
    public int ClassId {get;set;}
    public string? Description {get;set;} 
    public List<StudentDTO>? Student {get;set;}
}
