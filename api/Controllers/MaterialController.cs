using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("/material")]
public class MaterialController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public MaterialController(DatabaseContext dbContext)
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

