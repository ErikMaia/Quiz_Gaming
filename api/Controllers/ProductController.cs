using System;
using System.Collections.Generic;
using System.Linq;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {
        private DatabaseContext _context;

        private ProductModel getModel(ProductDTO dto){
            var product = new ProductModel();
            product.Name = dto.Name;
            product.Category = _context.Categories!.Find(dto.Category);// dto.Category;
            product.Description = dto.Description;
            product.Price = dto.Price ?? 0;
            product.ProductId = dto.ProductId ?? 0;
            return product;
        }
        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(){
            var allRows =_context.Products!.ToList();
            List<ProductDTO> allProducts = new List<ProductDTO>();
            foreach(var product in allRows){
                var productDTO = new ProductDTO(){
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category != null ? product.Category.CategoryId : 1
                };
                allProducts.Add(productDTO);
            } 
            return Accepted(allProducts);
        }
        
        [HttpGet("/product/{id}")]
        public ActionResult FindProduct(int id){
            var product = _context.Products!.Find(id);
            if(product == null){
                return NotFound();
            }
            var productDTO = new ProductDTO(){
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductId = product.ProductId,
                Category = product.Category?.CategoryId ?? 1
            };
            return Ok(productDTO);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDTO dto){
            try{
                var product = getModel(dto);
                //product.ProductId = _context.Products!.Max((e)=>e.ProductId)+1;

                _context.Products!.Add(product);
                _context.SaveChanges();
                return StatusCode(201);
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpPut]
        public ActionResult UpdateProduct(ProductDTO dto){
            var product = _context.Products!.Find(dto.ProductId);
            if(product != null){
                product.Description = dto.Description;
                product.Name = dto.Name;
                product.Price = dto.Price??0;
                product.Category = _context.Categories!.Find(dto.Category);
                _context.SaveChanges();
                return Ok();
            }           
            return BadRequest();
        }

        [HttpDelete("/product/{id}")]
        public ActionResult Delete(int id){
            var product = _context.Products!.Find(id);
            if(product == null)
                return BadRequest();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}