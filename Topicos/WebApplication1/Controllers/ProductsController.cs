using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisModelos;

namespace WebApplication1.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            var elResultado = new List <ProductsDto> ();
            return Ok(elResultado);
        }

        internal ProductsDto BuscarProducto(int orderId)
        {
            var elProducto = new ProductsDto ();
            return elProducto;
        }


        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var elProducto = BuscarProducto(id);
            if (elProducto == null)
                return NotFound();
            return Ok(elProducto);
        }

    }
}
