using api.core.Models;
using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("/student")]
public class StudentController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public StudentController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Index()
    {

        return Ok();
    }
    [HttpPost]
    public IActionResult Create(StudentDTO dto)
    {
        try
        {
            var student = new StudentModel() { 
                Email = dto.Email, 
                FirstName = dto.FirstName, 
                LastName = dto.LastName, 
                Password = dto.Password
            };
            _dbContext.Student!.Add(student);
            _dbContext.SaveChanges();
            return StatusCode(201);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        return Ok();
    }
    [HttpPost("login")]
    public ActionResult Login(StudentDTO dto)
    {
        string username = dto.Email!;
        string password = dto.Password!;
        var user = _dbContext.Student!.First((u) => u.Email == username && u.Password == password);
        return Ok(user);
    }
}
