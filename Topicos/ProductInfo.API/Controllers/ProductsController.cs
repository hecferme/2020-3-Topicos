using Microsoft.AspNetCore.Mvc;
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
        public JsonResult GetProducts()
        {
            JsonResult resultado = new JsonResult (
                new List<Object>()
                {
                    new {id = 10, Name = "Milk"},
                    new {id = 20, Name = "Coffee"}
                });
            return resultado;
        }
    }
}
