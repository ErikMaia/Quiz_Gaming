using System;
using System.Linq;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/table")]
    public class TableController : ControllerBase
    {
        private DatabaseContext _context;

        public TableController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(){
            var tables = _context.Tables!.ToArray();
            return Ok(tables);
        }

        [HttpGet("/table/{id}")]
        public ActionResult Find(int id){
            var table = _context.Tables!.Find(id);
            if(table != null){
                return Ok(table);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Create(int id){
            try{
                var table = new TableModel();
                table.IsFree = true;
                // table.TableId = id;
                table.TimesOpen = DateTime.Now;
                _context.Tables!.Add(table);
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpDelete("/table/{id}")]
        public ActionResult Delete(int id){
            var table = _context.Tables!.Find(id);
            if (table != null){
                _context.Tables!.Remove(table);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(TableDTO table){
            var rowToChange = _context.Tables!.Find(table.TableId);
            if(rowToChange != null){
                rowToChange.IsFree = table.IsFree;
                rowToChange.TimesOpen = DateTime.Now;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}