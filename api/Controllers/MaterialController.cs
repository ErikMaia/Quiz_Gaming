using api.core.Models;
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
        var material =_dbContext.Material!.ToList();
        return Ok(material);
    }
    [HttpPost]
    public IActionResult Create(MaterialModel model)
    {
        _dbContext.Material!.Add(model);
        _dbContext.SaveChanges();
        return StatusCode(201);
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        var one = _dbContext.Material!.Find(id);
        if (one != null)
            return Ok(one);
        return NotFound();
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var remove = _dbContext.Material!.Find(id);
        if(remove == null) 
            return NotFound();
        _dbContext.Material!.Remove(remove);
        _dbContext.SaveChanges();
        return Ok();
    }
}

