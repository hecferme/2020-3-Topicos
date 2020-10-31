using Microsoft.AspNetCore.Mvc;
using ProductInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        //[HttpGet("api/products")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            //JsonResult resultado = new JsonResult (
            //    new List<Object>()
            //    {
            //        new {id = 10, Name = "Milk"},
            //        new {id = 20, Name = "Coffee"}
            //    });
            var resultado = ProductsDataStore.Current.ProductsList;
            return Ok (resultado);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct (int id)
        {
            Product elProducto = ProductsDataStore.Current.ProductsList.FirstOrDefault
                        (p => p.Id == id);
            if (elProducto == null)
            {
                return NotFound();
            }
            return Ok(elProducto);
        }
    }
}
