using System;
using System.Linq;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        public CategoryController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _dbContext.Categories!.ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpGet("/category/{id}")]
        public IActionResult Find(int id)
        {
            var category = _dbContext.Categories!.Find(id);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest("Categoria não encontrada");

        }

        [HttpPost]
        public IActionResult Create(CategoryDTO dto)
        {
            try
            {
                var category = new CategoryModel(){
                    CategoryName = dto.CategoryName
                };
                _dbContext.Categories!.Add(category);
                _dbContext.SaveChanges();
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("/category/{id}")]
        public IActionResult Delete(int id)
        {
            var rowToRemove = _dbContext.Categories!.Find(id);
            if(rowToRemove != null){
                _dbContext.Categories.Remove(rowToRemove);
                _dbContext.SaveChanges();
                return Accepted();
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO category)
        {
            var rowToChange = _dbContext.Categories!.Find(category.CategoryId);
            if (rowToChange != null)
            {
                rowToChange.CategoryName = category.CategoryName;
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}