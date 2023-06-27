using System;
using System.Linq;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/waiter")]
    public class WaiterController : ControllerBase
    {
        private DatabaseContext _dbContext;

        public WaiterController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        private WaiterModel getModel(WaiterDTO dto){
            var model = new WaiterModel();
            if(dto.FistName == null){
                throw new System.Exception("Primeiro nome não informado");
            }
            if(dto.LastName == null){
                throw new System.Exception("Sobrenome não informado");
            }
            model.FistName = dto.FistName;
            model.LastName = dto.LastName;
            model.Fone = dto.Fone ?? 0;
            model.WaiterId = dto.WaiterId ?? 0;
            
            return model;
        }

        [HttpPost]
        public ActionResult Create(WaiterDTO dto){
            try{
                var waiter = getModel(dto);
                // waiter.WaiterId = _dbContext.Waiters!.Max(e=>e.WaiterId)+1;
                _dbContext.Waiters!.Add(waiter);
                _dbContext.SaveChanges();
                return Ok();
            } 
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpGet]
        public ActionResult Index(){
            var waiter = _dbContext.Waiters!.ToList();
            return Ok(waiter);
        }

        [HttpGet("/waiter/{id}")]
        public ActionResult Find(int id){
            var waiter = _dbContext.Waiters!.Find(id);
            if(waiter == null){
                return NotFound();
            }
            return Ok(waiter);
        }

        [HttpPut]
        public ActionResult Update(WaiterDTO waiter){
            var rowToUpdate = _dbContext.Waiters!.Find(waiter.WaiterId);
            if (rowToUpdate != null && waiter.FistName != null && waiter.LastName != null)
            {
                rowToUpdate.FistName = waiter.FistName;
                rowToUpdate.LastName = waiter.LastName;
                rowToUpdate.Fone = waiter.Fone??0;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("/waiter/{id}")]
        public ActionResult Delete(int id){
            var waiterToRemove = _dbContext.Waiters!.Find(id);
            if(waiterToRemove == null){
                return NotFound();
            }
            _dbContext.Waiters!.Remove(waiterToRemove);
            return Ok();
        }
    }
}