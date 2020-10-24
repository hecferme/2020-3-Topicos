using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetOrders ()
        {
            JsonResult elResultado = new JsonResult(new List<Object>() {
                 new {id = 5, orderDate=DateTime.Now},
                 new {id = 25, orderDate=DateTime.Now.AddMinutes(-200)}
            });
            return  elResultado;
        }
    }
}
