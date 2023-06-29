using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("/quizz")]
public class QuizzController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public QuizzController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Index()
    {

        return Ok();
    }
    [HttpPost]
    public IActionResult Create(StudentDTO student)
    {

        return StatusCode(201);
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
}

