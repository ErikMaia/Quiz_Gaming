using api.core.Models;
using api.DTOs;
using Api.Utils;
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

    [HttpPost]
    public IActionResult Create(StudentDTO dto)
    {
        try
        {
            var student = new StudentModel() { 
                Email = dto.Email, 
                FirstName = dto.FirstName, 
                LastName = dto.LastName, 
                Password = Crypto.criptograph(dto.Password!)
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
    [HttpPost("login")]
    public ActionResult Login(StudentDTO dto)
    {
        string username = dto.Email!;
        string password = dto.Password!;
        var user = _dbContext.Student!.First((u) => u.Email == username && u.Password == Crypto.criptograph(password));
        if(user == null){
            return NotFound();
        }
        return Ok(user);
    }
}
