using api.core.Models;
using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("/classroom")]
public class ClassRoomController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public ClassRoomController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var classroom = _dbContext.ClassRoom!.ToList();
        return Ok(classroom);
    }
    [HttpPost]
    public IActionResult Create(ClassRoomDTO dto)
    {
        try{
            var student = new ClassRoomModel(){
                Description = dto.Description,
                Student = new List<StudentModel>(),
            };
            _dbContext.ClassRoom!.Add(student);
            _dbContext.SaveChanges();
            return StatusCode(201);
        }
        catch(Exception e){
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        var one =_dbContext.ClassRoom!.Find(id);
        if(one != null)
            return Ok(one);
        return NotFound();
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var remove = _dbContext.ClassRoom!.Find(id);
        if(remove == null)
        return BadRequest();
        _dbContext.ClassRoom!.Remove(remove);
        _dbContext.SaveChanges();
        return Ok();
    }
}

