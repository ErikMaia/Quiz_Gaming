using api.core.Models;
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
        var quizz = _dbContext.Quiz!.ToList();
        return Ok(quizz);
    }
    [HttpPost]
    public IActionResult Create(QuizzModel model)
    {
        _dbContext.Quiz!.Add(model);
        _dbContext.SaveChanges();
        return StatusCode(201);
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        var quiz = _dbContext.Quiz!.Find(id);
        if (quiz != null)
            return Ok(quiz);
        return NotFound();
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var remove = _dbContext.Quiz!.Find(id);
        if (remove == null){
            return NotFound();
        }
        _dbContext.Quiz!.Remove(remove);
        _dbContext.SaveChanges();
        return Ok();
    }
}

